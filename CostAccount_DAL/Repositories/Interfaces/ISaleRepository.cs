using CostAccount_DAL.Models;

namespace CostAccount_DAL.Repositories.Interfaces
{
    public interface ISaleRepository : IRepository<Sale>
    {
        void DeleteAll();
    }
}
