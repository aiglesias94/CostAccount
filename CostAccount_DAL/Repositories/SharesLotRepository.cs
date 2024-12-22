using CostAccount_DAL.Data;
using CostAccount_DAL.Models;
using CostAccount_DAL.Repositories.Interfaces;

namespace CostAccount_DAL.Repositories
{
    //All this methods would be async if a real db was used
    public class SharesLotRepository : ISharesLotRepository
    {
        private readonly MemoryDB _memoryDB;

        public SharesLotRepository(MemoryDB memoryDB)
        {
            _memoryDB = memoryDB;
        }

        public void Add(SharesLot entity)
        {
            _memoryDB.Lots.Add(entity);
        }

        public void Delete(Guid id)
        {
            int index = _memoryDB.Lots.FindIndex(x => x.Id == id);
            if (index != -1)
                _memoryDB.Lots.RemoveAll(item => item.Id == id);
        }

        public void DeleteAll()
        {
            _memoryDB.Lots.Clear();
        }

        public IEnumerable<SharesLot> GetAll()
        {
            return _memoryDB.Lots;
        }

        public SharesLot? GetById(Guid id)
        {
            int index = _memoryDB.Lots.FindIndex(x => x.Id == id);
            if (index != -1)
                return _memoryDB.Lots.ElementAt(index);
            return null;
        }

        public SharesLot? GetByPriority(int priority)
        {
            int index = _memoryDB.Lots.FindIndex(x => x.Priority == priority);
            if (index != -1)
                return _memoryDB.Lots.ElementAt(index);
            return null;
        }

        public int GetHighestPriority()
        {
            if (_memoryDB.Lots.Count == 0) return -1;
            return _memoryDB.Lots.Min(x => x.Priority);
        }

        public int GetLowestPriority()
        {
            if (_memoryDB.Lots.Count == 0) return -1;
            return _memoryDB.Lots.Max(x => x.Priority);
        }

        public decimal GetTotalPrice()
        {
            return _memoryDB.Lots.Sum(x => x.TotalPrice);
        }

        public int GetTotalAmount()
        {
            return _memoryDB.Lots.Sum(x => x.Amount);
        }

        public bool UpdateAmount(Guid id, int amount)
        {
            int index = _memoryDB.Lots.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                SharesLot sharesLot = _memoryDB.Lots.ElementAt(index);
                sharesLot.Amount = amount;
                return true;
            }
            return false;
        }
    }
}
