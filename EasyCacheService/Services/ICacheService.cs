using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCacheService.Services
{
    public interface ICacheService
    {
        List<int> DeserializeListOfInts(byte[] bytes);
        byte[] Serialize(List<int> listOfInts);
    }
}
