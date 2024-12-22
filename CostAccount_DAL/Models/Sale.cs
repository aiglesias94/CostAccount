namespace CostAccount_DAL.Models
{
    public class Sale
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }


        public decimal CostBasisSoldShares { get { return Amount > 0 ? Price / Amount : 0; } }

        public int RemainingShares { get; set; }

        public decimal CostBasisRemainingShares { get; set; }

        public decimal TotalProfit { get { return SalePrice - Price; } }

        public DateTime Created { get; set; }

        public Sale(int amount, decimal price, decimal salePrice, int remainingShares, decimal costBasisRemainingShares)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Price = price;
            SalePrice = salePrice;
            Created = DateTime.Now;
            RemainingShares = remainingShares;
            CostBasisRemainingShares = costBasisRemainingShares;
        }
    }
}
