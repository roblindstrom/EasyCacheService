using EasyCacheService.Services;
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
    public class CacheServiceTests
    {
        public CacheServiceTests()
        {

        }

        [Fact]
        public void DeserializeListOfIntsShouldReturnListOfInts()
        {
            //Arrange
            var sut = new CacheService<It.IsAnyType>();
            var listOfints = new List<int>();
            listOfints.Add(1);
            var byteArray = sut.Serialize(listOfints);

            //Act
            var result = sut.DeserializeListOfInts(byteArray);
            //Assert
            result.ShouldBeOfType<List<int>>();
        }

        [Fact]
        public void DeserializeListOfStringsShouldReturnListOfStrings()
        {
            //Arrange
            var sut = new CacheService<It.IsAnyType>();
            var listOfstrings = new List<string>();
            listOfstrings.Add(" ");
            var byteArray = sut.Serialize(listOfstrings);
            //Act
            var result = sut.DeserializeListOfStrings(byteArray);
            //Assert
            result.ShouldBeOfType<List<string>>();
        }

        [Fact]
        public void DeserializeToListOfObjectsShouldReturnListOfObjects()
        {
            //Arrange
            var sut = new CacheService<Object>();
            var listOfObjects = new List<Object>();
            listOfObjects.Add(new Object { });
            var byteArray = sut.Serialize(listOfObjects);
            //Act
            var result = sut.DeserializeToListOfObjects(byteArray);
            //Assert
            result.ShouldBeOfType<List<Object>>();
        }

        [Fact]
        public void SerializeShouldReturnByteArrayFromListOfObjects()
        {
            //Arrange
            var listOfObjects = new List<Object>();
            listOfObjects.Add(new Object { });

            //Act
            var sut = new CacheService<Object>();
            var result = sut.Serialize(listOfObjects);
            //Assert
            result.ShouldBeOfType<Byte[]>();
        }

        [Fact]
        public void SerializeShouldReturnByteArrayFromListOfInts()
        {
            //Arrange
            
            var listOfints = new List<int>();
            listOfints.Add(1);

            //Act
            var sut = new CacheService<It.IsAnyType>();
            var result = sut.Serialize(listOfints);
            //Assert
            result.ShouldBeOfType<Byte[]>();
        }

        [Fact]
        public void SerializeShouldReturnByteArrayFromListOfStrings()
        {
            //Arrange
            var listOfstrings = new List<string>();
            listOfstrings.Add(" ");

            //Act
            var sut = new CacheService<It.IsAnyType>();
            var result = sut.Serialize(listOfstrings);
            //Assert
            result.ShouldBeOfType<Byte[]>();
        }
    }
}
