using CostAccount_DAL.Data;
using CostAccount_DAL.Models;
using CostAccount_DAL.Repositories.Interfaces;

namespace CostAccount_DAL.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MemoryDB _memoryDB;

        public SaleRepository(MemoryDB memoryDB)
        {
            _memoryDB = memoryDB;
        }


        public void Add(Sale entity)
        {
            _memoryDB.Sales.Add(entity);
        }

        public void Delete(Guid id)
        {
            int index = _memoryDB.Sales.FindIndex(x => x.Id == id);
            if (index != -1)
                _memoryDB.Sales.RemoveAll(item => item.Id == id);
        }

        public void DeleteAll()
        {
            _memoryDB.Sales.Clear();
        }

        public IEnumerable<Sale> GetAll()
        {
            return _memoryDB.Sales;
        }

        public Sale? GetById(Guid id)
        {
            int index = _memoryDB.Sales.FindIndex(x => x.Id == id);
            if (index != -1)
                return _memoryDB.Sales.ElementAt(index);
            return null;
        }
    }
}
