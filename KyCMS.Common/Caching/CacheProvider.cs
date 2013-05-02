using System;

namespace KyCMS.Common.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheProvider
    {
        #region Fields
        public static TimeSpan DefaultSlidingExpiration = TimeSpan.FromMinutes(1);
        #endregion

        #region .ctor
        static CacheProvider()
        {
            Cache = new DefaultCache();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the cache.
        /// </summary>
        /// <value>
        /// The cache.
        /// </value>
        public static ICache Cache { get; set; }

        private static ICache _repositoryCache = new RegionCache(Cache, "Repository");
        /// <summary>
        /// Gets the repository cache.
        /// </summary>
        /// <value>
        /// The repository cache.
        /// </value>
        public static ICache RepositoryCache
        {
            get
            {
                return _repositoryCache;
            }
        }

        private static ICache _serviceCache = new RegionCache(Cache, "Service");
        /// <summary>
        /// Gets the service cache.
        /// </summary>
        /// <value>
        /// The service cache.
        /// </value>
        public static ICache ServiceCache
        {
            get
            {
                return _serviceCache;
            }
        }
        #endregion

    }
}
