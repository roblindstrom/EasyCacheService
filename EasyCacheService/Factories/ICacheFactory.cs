using EasyCacheService.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Factories
{
    public interface ICacheFactory
    {
        /// <summary>
        /// Gets the chosen cache from the factory using Enum. Alternatives available: CacheName.DistributedCache, CacheName.InMemoryCache
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICache GetCache(CacheName name);
    }
}
