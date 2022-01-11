using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Caches
{
    public class InMemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;
        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<byte[]> GetCacheAsync(Guid guid)
        {
            await Task.Run(() =>
            {
                var cacheEntry = _memoryCache.Get<byte[]>(guid);
                return cacheEntry;
            });
            return null;
        }

        public async Task SetCacheAsync(byte[] byteArray, Guid guid)
        {
            await Task.Run(() =>
            {
                _memoryCache.Set(guid.ToString(), byteArray);
            });
        }

    }
}
