namespace Basket.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);

        Task<TEntity> GetById(string id);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(TEntity obj);

        Task Remove(string id);

        void Dispose();
    }
}
