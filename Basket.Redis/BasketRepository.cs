using Basket.BLL.LogicServices;
using Basket.Entities.Entities;
using Basket.Redis.Entities;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Bson.IO;
using ServiceStack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Basket.Redis
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        private readonly IService<TblItem> _itemService;

        public BasketRepository(IDistributedCache cache, IService<TblItem> itemService)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
            _itemService = itemService;
        }
        public async Task<TblBasket> Get(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonSerializer.Deserialize<TblBasket>(basket);
        }

        public async Task<TblBasket> Update(string UserName, TblBasket basket)
        {
            if (await Get(basket.UserName) != null)
                throw new Exception("userName exist,pls enter different userName");

            var remove = _redisCache.RemoveAsync(UserName);
            var insert = _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize<TblBasket>(basket));

            await Task.WhenAll(remove, insert);

            return await Get(basket.UserName);
        }
        public async Task Delete(string userName)
        {
            if (await Get(userName) == null)
                throw new Exception("userName is not exist ");

            await _redisCache.RemoveAsync(userName);
        }

        public async Task Create(TblBasket basket)
        {
            if (await Get(basket.UserName) != null)
                throw new Exception("userName exist ,pls enter different userName");

            await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize<TblBasket>(basket));
        }

        public async Task<TblBasket> AddToBasket(string userName, string itemId)
        {
            var basket = await Get(userName);
            if (basket == null)
                throw new Exception("userName is not exist ");

            var item = _itemService.GetById(itemId).Result;
            if (item == null)
                throw new Exception("item ID is wrong");

            basket.Items.Add(item);
            await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize<TblBasket>(basket));

            return await Get(userName);
        }

    }



}
