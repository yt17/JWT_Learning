using CORE.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(cache) as dynamic;


            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {

                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);


                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
        }
    }
}
