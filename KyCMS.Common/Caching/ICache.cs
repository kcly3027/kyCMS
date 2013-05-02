using System;
using System.Web.Caching;

namespace KyCMS.Common.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICache
    {
        #region Methods

        object Add(string key, object value);
        object Add(string key, object value, CacheItemRemovedCallback onRemoveCallback);
        object Add(string key, object value, DateTime absoluteExpiration);
        object Add(string key, object value, TimeSpan slidingExpiration);
        object Add(string key, object value, DateTime absoluteExpiration, CacheItemRemovedCallback onRemoveCallback);
        object Add(string key, object value, TimeSpan slidingExpiration, CacheItemRemovedCallback onRemoveCallback);
        object Add(string key, object value, CacheDependency dependencies);
        object Add(string key, object value, CacheDependency dependencies, CacheItemRemovedCallback onRemoveCallback);
        object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, CacheItemRemovedCallback onRemoveCallback);
        object Add(string key, object value, CacheDependency dependencies, TimeSpan slidingExpiration, CacheItemRemovedCallback onRemoveCallback);
        object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        object Get(string key);

        #endregion
    }
}
