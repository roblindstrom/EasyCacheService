using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Caches
{
    public interface ICache
    {
        /// <summary>
        /// Gets the current content of the saved cache connected to the guid provided.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<byte[]> GetCacheAsync(Guid guid);

        /// <summary>
        /// Saves the content of the Byte Array to the guid provided. The content is saved for 10 minutes and timer resets if cache is set again
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task SetCacheAsync(byte[] byteArray, Guid guid);
    }
}
