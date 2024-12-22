namespace CostAccount_DAL.Repositories.Interfaces
{
    //All this methods would be async if a real db was used
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(Guid id);
        void Add(TEntity entity);
        void Delete(Guid id);
    }
}
