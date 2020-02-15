using System;
using System.Runtime.Caching;

namespace Cheap.Awesome.API.Utils
{
    public static class MemoryCacher
    {
        public static bool TryGetValue(string key, out object memCache )
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memCache =  memoryCache.Get(key);
            if (memCache != null)
                return true;
            else
                return false;
        }

        public static bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }

        public static void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }
    }
}
