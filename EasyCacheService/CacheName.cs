using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService
{
    public enum CacheName
    {
        NotFound = 0,
        DistributedCache = 1,
        InMemoryCache = 2,
    }
}
