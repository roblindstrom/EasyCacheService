using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Services
{
    public interface ICacheService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Deserilizes from Byte Array into list of ints
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        List<int> DeserializeListOfInts(byte[] bytes);
        /// <summary>
        /// Deserializes from Byte Array into list of strings
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        List<string> DeserializeListOfStrings(byte[] bytes);

        /// <summary>
        /// Deserializes from Byte Array into list of Objects. Which object type is decided when initializing the ICacheService
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        List<TEntity> DeserializeToListOfObjects(byte[] bytes);

        /// <summary>
        /// Serializes into Byte Array for storage in the cache. Overload for List of Objects, strings or int
        /// </summary>
        /// <param name="listOfInts"></param>
        /// <returns></returns>
        byte[] Serialize(List<TEntity> listOfInts);
        /// <summary>
        /// Serializes into Byte Array for storage in the cache. Overload for List of Objects, strings or int
        /// </summary>
        /// <param name="listOfInts"></param>
        /// <returns></returns>
        byte[] Serialize(List<string> listOfString);
        /// <summary>
        /// Serializes into Byte Array for storage in the cache. Overload for List of Objects, strings or int
        /// </summary>
        /// <param name="listOfInts"></param>
        /// <returns></returns>
        byte[] Serialize(List<int> listOfInts);
        


    }
}
