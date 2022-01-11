using EasyCacheService.Caches;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EasyCacheServiceTests
{
    public class DistributedCacheTests
    {
        private readonly Mock<IDistributedCache> _mockDistributedCache;

        public DistributedCacheTests()
        {
            _mockDistributedCache = new Mock<IDistributedCache>();
        }

        [Fact]
        public async Task GetCacheAsyncShouldReturnByteArray()
        {
            //Arrange
            var byteArray = new byte[1024];
            _mockDistributedCache.Setup(distribCache => distribCache.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(byteArray) ;
            //Act
            var sut = new DistributedCache(_mockDistributedCache.Object);
            var result = await sut.GetCacheAsync(Guid.NewGuid());
            //Assert
            result.ShouldBeOfType<byte[]>();
        }

        [Fact]
        public async Task GetCacheAsyncShouldCallGetAsyncOnce()
        {
            //Arrange
            var byteArray = new byte[1024];
            _mockDistributedCache.Setup(distribCache => distribCache.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(byteArray);
            //Act
            var sut = new DistributedCache(_mockDistributedCache.Object);
            var result = await sut.GetCacheAsync(Guid.NewGuid());
            //Assert
            _mockDistributedCache.Verify(distribCache => distribCache.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [Fact]
        public async Task SetCacheAsyncShouldCallSetAsyncOnce()
        {
            //Arrange
            var byteArray = new byte[1024];
            _mockDistributedCache.Setup(distribCache => distribCache.SetAsync(It.IsAny<string>(), It.IsAny<Byte[]>(), It.IsAny<DistributedCacheEntryOptions>(), It.IsAny<CancellationToken>()));
            //Act
            var sut = new DistributedCache(_mockDistributedCache.Object);
            await sut.SetCacheAsync(byteArray, Guid.NewGuid());
            //Assert
            _mockDistributedCache.Verify(distribCache => distribCache.SetAsync(It.IsAny<string>(), It.IsAny<Byte[]>(), It.IsAny<DistributedCacheEntryOptions>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}