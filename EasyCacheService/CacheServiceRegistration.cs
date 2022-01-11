using EasyCacheService.Factories;
using EasyCacheService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCacheService
{
    public static class CacheServiceRegistration
    {
        public static IServiceCollection EzCacheServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICacheService<>), typeof(CacheService<>));

            services.AddScoped<ICacheFactory, CacheFactory>();

            services.AddDistributedMemoryCache();

            return services;
        }
    }

}