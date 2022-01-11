using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Caches
{
    public interface ICache
    {
        Task<byte[]> GetCacheAsync(Guid guid);

        Task SetCacheAsync(byte[] byteArray, Guid guid);
    }
}
