﻿using Microsoft.Extensions.Caching.Memory;
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
            var toBeReturned = await Task.Run(() =>
            {
                _memoryCache.TryGetValue(guid, out Byte[] cacheEntry);
                return cacheEntry;
            });
            return toBeReturned;
        }

        public async Task SetCacheAsync(byte[] byteArray, Guid guid)
        {
            await Task.Run(() =>
            {
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _memoryCache.Set(guid, byteArray, cacheExpiryOptions);
            });
        }

    }
}
