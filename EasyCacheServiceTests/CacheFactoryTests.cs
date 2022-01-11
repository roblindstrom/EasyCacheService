using EasyCacheService;
using EasyCacheService.Caches;
using EasyCacheService.Factories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EasyCacheServiceTests
{
    public class CacheFactoryTests
    {
        private readonly Mock<IDistributedCache> _mockDistributedCache;
        private readonly Mock<IMemoryCache> _mockMemoryCache;

        public CacheFactoryTests()
        {
            _mockDistributedCache = new Mock<IDistributedCache>();
            _mockMemoryCache = new Mock<IMemoryCache>();
        }

        [Fact]
        public void GetCacheShouldReturnDistributedCache()
        {
            //Arrange
            //Act
            var sut = new CacheFactory(_mockDistributedCache.Object, _mockMemoryCache.Object);
            var result = sut.GetCache(CacheName.DistributedCache);
            //Assert
            result.ShouldBeOfType<DistributedCache>();
        }
        [Fact]
        public void GetCacheShouldReturnInMemoryCache()
        {
            //Arrange
            //Act
            var sut = new CacheFactory(_mockDistributedCache.Object, _mockMemoryCache.Object);
            var result = sut.GetCache(CacheName.InMemoryCache);
            //Assert
            result.ShouldBeOfType<InMemoryCache>();
        }

    }
}
