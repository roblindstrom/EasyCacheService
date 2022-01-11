using EasyCacheService.Caches;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyCacheServiceTests
{
    public class InMemoryTests
    {
        private readonly Mock<IMemoryCache> _mockMemoryCache;

        public InMemoryTests()
        {
            _mockMemoryCache = new Mock<IMemoryCache>();
        }

        [Fact]
        public async Task GetCacheAsyncShouldReturnByteArray()
        {
            //Arrange
            var byteArray = new byte[1024];
            _mockMemoryCache.Setup(memoryCache => memoryCache.TryGetValue(It.IsAny<string>(), out byteArray)).Returns(It.IsAny<bool>);
            //Act
            var sut = new InMemoryCache(_mockMemoryCache.Object);
            var result = await sut.GetCacheAsync(Guid.NewGuid());
            //Assert
            result.ShouldBeOfType<byte[]>();
        }

        [Fact]
        public async Task GetCacheAsyncShouldCallGetAsyncOnce()
        {
            //Arrange
            var byteArray = new byte[1024];
            _mockMemoryCache.Setup(memoryCache => memoryCache.TryGetValue(It.IsAny<string>(), out byteArray));
            //Act
            var sut = new InMemoryCache(_mockMemoryCache.Object);
            var result = await sut.GetCacheAsync(Guid.NewGuid());
            //Assert
            _mockMemoryCache.Verify(distribCache => distribCache.TryGetValue(It.IsAny<string>(), out byteArray), Times.Once());

        }

        [Fact]
        public async Task SetCacheAsyncShouldCallSetAsyncOnce()
        {
            //Arrange
            var byteArray = new byte[1024];
            _mockMemoryCache.Setup(memoryCache => memoryCache.Set(It.IsAny<string>(), byteArray, It.IsAny<MemoryCacheEntryOptions>()));
            //Act
            var sut = new InMemoryCache(_mockMemoryCache.Object);
            await sut.SetCacheAsync(byteArray, Guid.NewGuid());
            //Assert
            _mockMemoryCache.Verify(distribCache => distribCache.Set(It.IsAny<string>(), byteArray, It.IsAny<MemoryCacheEntryOptions>()), Times.Once());
        }
    }
}
