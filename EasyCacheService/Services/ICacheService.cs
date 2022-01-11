using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Services
{
    public interface ICacheService<TEntity> where TEntity : class
    {
        List<int> DeserializeListOfInts(byte[] bytes);

        List<string> DeserializeListOfStrings(byte[] bytes);


        List<TEntity> DeserializeToListOfObjects(byte[] bytes);


        byte[] Serialize(List<TEntity> listOfInts);

        byte[] Serialize(List<string> listOfString);

        byte[] Serialize(List<int> listOfInts);
        


    }
}
