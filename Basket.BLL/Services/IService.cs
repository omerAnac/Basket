namespace Basket.BLL.LogicServices
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T model);
        Task<bool> Update(T model);
        Task<bool> DeleteById(string id);
    }
}
