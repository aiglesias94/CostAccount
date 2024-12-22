using CostAccount_DAL.Enums;

namespace CostAccount_DAL.Models
{
    public class SharesLot
    {
        public Guid Id { get; private set; }

        public int Priority { get; private set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public Month Month { get; set; }

        public DateTime Created { get; set; }

        public SharesLot(int amount, decimal price, int priority, Month month)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Price = price;
            Priority = priority;
            Month = month;
            Created = DateTime.Now;
        }

        public decimal TotalPrice
        {
            get { return Price * Amount; }
        }
    }
}
