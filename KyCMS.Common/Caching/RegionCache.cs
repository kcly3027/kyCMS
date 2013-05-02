using System;

namespace KyCMS.Common.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionCache : ICache
    {
        #region fileds

        ICache Cache = null;

        #endregion

        #region .ctor

        public RegionCache(ICache cache, string regionName)
        {
            Cache = cache;
            RegionName = regionName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of the region.
        /// </summary>
        /// <value>
        /// The name of the region.
        /// </value>
        public string RegionName { get; private set; }

        #endregion

        #region Methods

        public object Add(string key, object value)
        {
            return Cache.Add(RegionKey(key), value);
        }

        public object Add(string key, object value, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, onRemoveCallback);
        }

        public object Add(string key, object value, DateTime absoluteExpiration)
        {
            return Cache.Add(RegionKey(key), value, absoluteExpiration);
        }

        public object Add(string key, object value, TimeSpan slidingExpiration)
        {
            return Cache.Add(RegionKey(key), value, slidingExpiration);
        }

        public object Add(string key, object value, DateTime absoluteExpiration, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, absoluteExpiration, onRemoveCallback);
        }

        public object Add(string key, object value, TimeSpan slidingExpiration, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, slidingExpiration, onRemoveCallback);
        }

        public object Add(string key, object value, System.Web.Caching.CacheDependency dependencies)
        {
            return Cache.Add(RegionKey(key), value, dependencies);
        }

        public object Add(string key, object value, System.Web.Caching.CacheDependency dependencies, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, dependencies, onRemoveCallback);
        }

        public object Add(string key, object value, System.Web.Caching.CacheDependency dependencies, DateTime absoluteExpiration, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, dependencies, absoluteExpiration, onRemoveCallback);
        }

        public object Add(string key, object value, System.Web.Caching.CacheDependency dependencies, TimeSpan slidingExpiration, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, dependencies, slidingExpiration, onRemoveCallback);
        }

        public object Add(string key, object value, System.Web.Caching.CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, System.Web.Caching.CacheItemPriority priority, System.Web.Caching.CacheItemRemovedCallback onRemoveCallback)
        {
            return Cache.Add(RegionKey(key), value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        public void Remove(string key)
        {
            Cache.Remove(RegionKey(key));
        }

        public object Get(string key)
        {
            return Cache.Get(RegionKey(key));
        }

        /// <summary>
        /// Regions the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string RegionKey(string key)
        {
            return RegionName + "_" + key;
        }
        #endregion
    }
}
