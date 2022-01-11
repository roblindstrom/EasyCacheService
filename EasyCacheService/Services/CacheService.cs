using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Services
{
    public class CacheService : ICacheService
    {
        public List<int> DeserializeListOfInts(byte[] bytes)
        {
            var asString = Encoding.Unicode.GetString(bytes);
            return JsonConvert.DeserializeObject<List<int>>(asString);
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
