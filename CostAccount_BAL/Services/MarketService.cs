using CostAccount_BAL.Services.Interfaces;
using CostAccount_DAL.DTOs;
using CostAccount_DAL.Enums;
using CostAccount_DAL.Models;
using CostAccount_DAL.Repositories.Interfaces;

namespace CostAccount_BAL.Services
{
    public class MarketService : IMarketService
    {
        private readonly ISharesLotRepository _sharesLotRepository;
        private readonly ISaleRepository _saleRepository;

        public MarketService(ISharesLotRepository sharesLotRepository, ISaleRepository saleRepository)
        {
            _sharesLotRepository = sharesLotRepository;
            _saleRepository = saleRepository;
        }
        public SharesLotDTO Purchase(int amount, decimal price, Month month)
        {
            int lowestPriority = _sharesLotRepository.GetLowestPriority();
            //if not element exist, the getLowestPriority method will return -1 and by adding 1 the priority will be 0
            SharesLot sharesLot = new SharesLot(amount, price, lowestPriority + 1, month);
            _sharesLotRepository.Add(sharesLot);
            SharesLotDTO sharesLotDTO = SharesLotDTO.From(sharesLot);
            return sharesLotDTO;
        }

        public SaleDTO Sell(int amount, decimal price)
        {

            if (!ValidPurchase(amount, price)) throw new ArgumentException("Invalid amount");

            SharesLot? sharesLot = GetNextLot();
            int toSellAmount = amount;
            decimal totalPurchasePrice = 0;

            while (sharesLot != null && toSellAmount > 0)
            {
                if (sharesLot.Amount > toSellAmount)
                {

                    totalPurchasePrice += sharesLot.Price * toSellAmount;
                    _sharesLotRepository.UpdateAmount(sharesLot.Id, sharesLot.Amount - toSellAmount);
                    toSellAmount = 0;
                    break;
                }
                else
                {

                    totalPurchasePrice += sharesLot.TotalPrice;
                    _sharesLotRepository.Delete(sharesLot.Id);
                    toSellAmount -= sharesLot.Amount;
                }

                sharesLot = GetNextLot();
            }

            int reaminingShares = _sharesLotRepository.GetTotalAmount();
            decimal costBasisRemainingShares = _sharesLotRepository.GetTotalPrice() / reaminingShares;

            Sale sale = new Sale(amount, totalPurchasePrice, amount * price, reaminingShares, costBasisRemainingShares);
            _saleRepository.Add(sale);

            SaleDTO saleDTO = SaleDTO.From(sale);
            return saleDTO;
        }


        public List<SharesLotDTO> GetLots()
        {
            IEnumerable<SharesLot> sharesLots = _sharesLotRepository.GetAll();
            List<SharesLotDTO> dtos = sharesLots.Select(sl => SharesLotDTO.From(sl)).ToList();
            return dtos;
        }

        public List<SaleDTO> GetSales()
        {
            IEnumerable<Sale> sales = _saleRepository.GetAll();
            List<SaleDTO> dtos = sales.Select(sale => SaleDTO.From(sale)).ToList();
            return dtos;
        }

        public void ResetLots()
        {
            _sharesLotRepository.DeleteAll();
            _saleRepository.DeleteAll();
            Purchase(100, 20, Month.January);
            Purchase(150, 30, Month.February);
            Purchase(120, 10, Month.March);
        }


        public bool ValidPurchase(int amount, decimal price)
        {
            return amount > 0 && _sharesLotRepository.GetTotalAmount() > amount;
        }

        private SharesLot? GetNextLot()
        {
            int highestPriority = _sharesLotRepository.GetHighestPriority();
            SharesLot? sharesLot = _sharesLotRepository.GetByPriority(highestPriority);
            return sharesLot;
        }


    }
}
