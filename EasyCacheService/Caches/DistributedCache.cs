using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Caches
{
    public class DistributedCache : ICache
    {
        private readonly IDistributedCache _distributedCache;
        public DistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public async Task<byte[]> GetCacheAsync(Guid guid)
        {
            var cached = await _distributedCache.GetAsync(guid.ToString());
            return cached;
        }

        public async Task SetCacheAsync(byte[] byteArray, Guid guid)
        {
            var options = new DistributedCacheEntryOptions()
           .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
           .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            await _distributedCache.SetAsync(guid.ToString(), byteArray, options);
        }
    }
}
