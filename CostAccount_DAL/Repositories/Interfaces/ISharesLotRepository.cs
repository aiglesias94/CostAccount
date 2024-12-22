using CostAccount_DAL.Models;

namespace CostAccount_DAL.Repositories.Interfaces
{
    //All this methods would be async if a real db was used
    public interface ISharesLotRepository: IRepository<SharesLot>
    {
        SharesLot? GetByPriority(int priority);
        int GetHighestPriority();
        int GetLowestPriority();
        decimal GetTotalPrice();
        int GetTotalAmount();
        bool UpdateAmount(Guid id, int amount);
        void DeleteAll();

    }
}
