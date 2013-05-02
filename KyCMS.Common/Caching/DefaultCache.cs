using System;
using System.Web;
using System.Web.Caching;

namespace KyCMS.Common.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultCache : ICache
    {

        public object Add(string key, object value)
        {
            return Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public object Add(string key, object value, CacheItemRemovedCallback onRemoveCallback)
        {
            return Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        }

        public object Add(string key, object value, DateTime absoluteExpiration)
        {
            return Add(key, value, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public object Add(string key, object value, TimeSpan slidingExpiration)
        {
            return Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Default, null);
        }

        public object Add(string key, object value, DateTime absoluteExpiration, CacheItemRemovedCallback onRemoveCallback)
        {
            return Add(key, value, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        }

        public object Add(string key, object value, TimeSpan slidingExpiration, CacheItemRemovedCallback onRemoveCallback)
        {
            return Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        }

        public object Add(string key, object value, CacheDependency dependencies)
        {
            return Add(key, value, dependencies, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public object Add(string key, object value, CacheDependency dependencies, CacheItemRemovedCallback onRemoveCallback)
        {
            return Add(key, value, dependencies, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        }

        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, CacheItemRemovedCallback onRemoveCallback)
        {
            return Add(key, value, dependencies, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        }

        public object Add(string key, object value, CacheDependency dependencies, TimeSpan slidingExpiration, CacheItemRemovedCallback onRemoveCallback)
        {
            return Add(key, value, dependencies, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        }

        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            return HttpRuntime.Cache.Add(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }
    }
}
