using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Common.Caching
{
    public static class CacheExtensions
    {
        public static bool IsExsits(ICache cache, string key)
        {
            object value = cache.Get(key);
            return value != null;
        }

        public static T Get<T>(ICache cache, string key)
        {
            object obj = cache.Get(key);
            if (obj == null) return default(T);
            return (T)obj;
        }
    }
}
