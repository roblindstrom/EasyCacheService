using EasyCacheService.Caches;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Factories
{
    public class CacheFactory : ICacheFactory
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IMemoryCache _memoryCache;
        public CacheFactory(IDistributedCache distributedCache, IMemoryCache memoryCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        public ICache GetCache(CacheName name)
        {
            switch (name)
            {
                case CacheName.DistributedCache:
                    return new DistributedCache(_distributedCache);

                case CacheName.InMemoryCache:
                    return new InMemoryCache(_memoryCache);

                default:
                    throw new ApplicationException(string.Format($"Cache {name} cant be found!"));
            }
        }
    }
}
