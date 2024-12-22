using CostAccount_DAL.Enums;
using CostAccount_DAL.Models;

namespace CostAccount_DAL.Data
{
    public class MemoryDB
    {
        public MemoryDB()
        {
            Lots = new List<SharesLot>();
            Sales = new List<Sale>();
            Seed();
        }

        public List<SharesLot> Lots { get; set; }

        public List<Sale> Sales { get; set; }

        private void Seed()
        {
            Lots.Add(new SharesLot(100, 20, 1, Month.January));
            Lots.Add(new SharesLot(150, 30, 2, Month.February));
            Lots.Add(new SharesLot(120, 10, 3, Month.March));

        }
    }
}
