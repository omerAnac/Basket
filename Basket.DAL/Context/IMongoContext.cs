using MongoDB.Driver;

namespace Basket.DAL.Context
{
    public interface IMongoContext
    {

        int SaveChanges();

        IMongoCollection<T> GetCollection<T>(string name);

        void Dispose();

        Task AddCommand(Func<Task> func);
    }
}
