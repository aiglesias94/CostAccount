using CostAccount_DAL.Enums;
using CostAccount_DAL.Models;

namespace CostAccount_DAL.DTOs
{
    public class SharesLotDTO
    {
        public Guid Id { get; private set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public Month Month { get; set; }

        public DateTime Created { get; set; }

        public decimal TotalPrice
        {
            get { return Price * Amount; }
        }

        public static SharesLotDTO From(SharesLot sharesLot)
        {
            SharesLotDTO dto = new SharesLotDTO()
            {
                Id = sharesLot.Id,
                Amount = sharesLot.Amount,
                Price = sharesLot.Price,
                Month = sharesLot.Month,
                Created = sharesLot.Created,
            };

            return dto;
        }


    }
}
