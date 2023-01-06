using Basket.DAL;

namespace Basket.BLL.LogicServices
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly Basket.DAL.Repositories.IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(Basket.DAL.Repositories.IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public virtual async Task Create(T model)
        {
            await _repository.Add(model);
            _unitOfWork.Commit();
        }

        public virtual async Task<bool> Update(T model)
        {
            await _repository.Update(model);
            return _unitOfWork.Commit();
        }

        public virtual async Task<bool> DeleteById(string id)
        {
            await _repository.Remove(id);
            return _unitOfWork.Commit();
        }

    }
}
