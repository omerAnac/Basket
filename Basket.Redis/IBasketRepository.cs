using Basket.Entities.Entities;
using Basket.Redis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Redis
{
    public interface IBasketRepository
    {
        Task<TblBasket> Get(string userName);
        Task<TblBasket> Update(string userName, TblBasket basket);
        Task Delete(string userName);
        Task Create(TblBasket tblBasket);
        Task<TblBasket> AddToBasket(string userName, string itemId);

    }
}
