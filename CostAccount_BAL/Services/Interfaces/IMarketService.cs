using CostAccount_DAL.Enums;
using CostAccount_DAL.DTOs;

namespace CostAccount_BAL.Services.Interfaces
{
    public interface IMarketService
    {
        SharesLotDTO Purchase(int amount, decimal price, Month month);
        SaleDTO Sell(int amount, decimal price);
        bool ValidPurchase(int amount, decimal price);
        List<SharesLotDTO> GetLots();
        public List<SaleDTO> GetSales();
        void ResetLots();

    }
}
