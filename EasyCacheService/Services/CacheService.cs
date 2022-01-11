using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Services
{
    public class CacheService<T> : ICacheService<T> where T : class
    {
        public List<int> DeserializeListOfInts(byte[] bytes)
        {
            var asString = Encoding.Unicode.GetString(bytes);
            return JsonConvert.DeserializeObject<List<int>>(asString);
        }
        public List<string> DeserializeListOfStrings(byte[] bytes)
        {
            var asString = Encoding.Unicode.GetString(bytes);
            return JsonConvert.DeserializeObject<List<string>>(asString);
        }

        public List<T> DeserializeToListOfObjects(byte[] bytes)
        {
            var asString = Encoding.Unicode.GetString(bytes);
            return JsonConvert.DeserializeObject<List<T>>(asString);
        }

        public byte[] Serialize(List<T> listOfObjects)
        {
            var asString = JsonConvert.SerializeObject(listOfObjects, SerializerSettings);
            return Encoding.Unicode.GetBytes(asString);
        }
        public byte[] Serialize(List<string> listOfString)
        {
            var asString = JsonConvert.SerializeObject(listOfString, SerializerSettings);
            return Encoding.Unicode.GetBytes(asString);
        }
        public byte[] Serialize(List<int> listOfInts)
        {
            var asString = JsonConvert.SerializeObject(listOfInts, SerializerSettings);
            return Encoding.Unicode.GetBytes(asString);
        }


        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
        };
    }
}
