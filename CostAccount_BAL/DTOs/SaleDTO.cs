using CostAccount_DAL.Models;
using System.Security.Cryptography;

namespace CostAccount_DAL.DTOs
{
    public class SaleDTO
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public decimal CostBasisSoldShares { get { return Price / Amount; } }

        public int RemainingShares { get; set; }

        public decimal CostBasisRemainingShares { get; set; }

        public decimal TotalProfit { get { return SalePrice - Price; } }

        public DateTime Created { get; set; }

        public static SaleDTO From(Sale sale)
        {
            SaleDTO dto = new SaleDTO()
            {
                Id = sale.Id,
                Amount = sale.Amount,
                Price = sale.Price,
                SalePrice = sale.SalePrice,
                RemainingShares = sale.RemainingShares,
                CostBasisRemainingShares = sale.CostBasisRemainingShares,
                Created = sale.Created,
            };

            return dto;
        }

        public static Sale To(SaleDTO saleDto)
        {
            Sale sale = new Sale(saleDto.Amount, saleDto.Price, saleDto.SalePrice, saleDto.RemainingShares, saleDto.CostBasisRemainingShares);
            return sale;
        }
    }
}
