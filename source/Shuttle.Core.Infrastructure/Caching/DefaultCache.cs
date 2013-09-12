using System;
using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public class DefaultCache : ICache
    {
        private Dictionary<string, object> cache;

        public DefaultCache()
        {
            Flush();
        }

        public void Flush()
        {
            cache = new Dictionary<string, object>();
        }

        public void Add(string key, object item)
        {
            if (cache.ContainsKey(key))
            {
                return;
            }

            try
            {
                cache.Add(key, item);
            }
            catch (Exception)
            {
                // ignore
            }
        }

        public T Get<T>(string key)
        {
            if (cache.ContainsKey(key))
            {
                try
                {
                    return (T)cache[key];
                }
                catch
                {
                    // ignore
                }
            }

            return default(T);
        }
    }
}
