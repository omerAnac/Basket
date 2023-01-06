using Basket.BLL.LogicServices;
using Basket.DAL;
using Basket.DAL.Repositories;
using Basket.Entities.Entities;

namespace Logging.BLL.LogicServices._LogicServices.LogService
{
    public class ItemService : Service<TblItem>, IItemService
    {
        public ItemService(IRepository<TblItem> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
       
    }
}
