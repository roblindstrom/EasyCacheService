using EasyCacheService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCacheService
{
    public static class CacheServiceRegistration
    {
        public static IServiceCollection EzCacheServices(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();

            services.AddDistributedMemoryCache();

            return services;
        }
    }

}