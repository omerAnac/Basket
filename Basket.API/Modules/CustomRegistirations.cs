using Autofac;
using Module = Autofac.Module;
using Basket.DAL.Repositories;
using Basket.BLL.LogicServices;
using Basket.DAL;
using Basket.DAL.Context;
using ServiceStack.Logging;
using ServiceStack.Script;
using Basket.Service.Mapping;
using Basket.Redis;
using Basket.Redis.Mapping;

namespace Basket.API.Modules
{
    public static class CustomRegistirations
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(MapProfile).Assembly));
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(BasketMapProfile).Assembly));

            services.AddStackExchangeRedisCache(options =>
             {
                 options.Configuration = configuration["CacheSettings:ConnectionString"];
             });



        }
    }
}
