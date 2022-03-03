using CORE.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.CrossCuttingConcerns
{
    public class MemoryCacheManager : ICacheManager 
    {
        private IMemoryCache cache;
        public MemoryCacheManager()
        {
            cache=ServiceTool.serviceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object data, int duration)
        {
            cache.Set(key, TimeSpan.FromMilliseconds(duration));
        }

        public T Get<T>(string key)
        {
            return cache.Get<T> (key);
        }

        public object Get(string key)
        {
            return cache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
           // cache.
        }
    }
}
