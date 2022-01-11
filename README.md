# EasyCacheService

## Installation
 Download latest EasyCacheService using Nuget Handler.

## Usage

Add services to ConfigureServices in Startup class
```c#
public void ConfigureServices(IServiceCollection services)
        {
	    services.AddScoped(typeof(ICacheService<>), typeof(CacheService<>));
            services.AddScoped<ICacheFactory, CacheFactory>();
	}
```


Import to the class you want to use the Cache service/factory by using dependency injection
```c#
using EasyCacheService;

public class CacheExampleClass
{
	private readonly ICacheFactory _cacheFactory;
        private readonly ICacheService<ObjectToBeCached> _cacheService;


        public CacheExampleClass(ICacheFactory cacheFactory, ICacheService<LineItemResponse> cacheService)
        {
            _cacheFactory=cacheFactory;
            _cacheService=cacheService;
        }
}
```

Use the factory to get the kind of cache you want to use and then use the service methods to get/set information to the cache.
The CacheKey is a guid that you setup to specify which cache you want to access. Making it possible to have several caches live at once.
```c#
using EasyCacheService;

public class CacheExampleClass
{
	public async Task AddObjectToCache(ObjectToBeCached Object, Guid CacheKey)
        {
            var listOfObjects = new List<(ObjectToBeCached>();
            
            //Get the cache you want from the factory, CacheName.InMemoryCache or CacheName.DistributedCache
            var cache = _cacheFactory.GetCache(CacheName.InMemoryCache);
	    
            var ObjectsFromCache = await cache.GetCacheAsync(CacheKey);
            //If cache is empty it will return null
            if (cartFromCache != null)
            {
		//Since cache was not empty, collect the objects from the cache
                listOfObjects = _cacheService.DeserializeToListOfObjects(ObjectsFromCache);
            }
            //Add the new object to the cache
            listOfObjects(Object);
            //Save everything into the cache
            await cache.SetCacheAsync(_cacheService.Serialize(listOfLineItems), CacheKey);
        }
}
```

This nuget contains overload for List of strings, ints and objects and uses guids to keep multiple saved caches available at once.

