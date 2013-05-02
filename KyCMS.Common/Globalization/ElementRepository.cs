using KyCMS.Common.Globalization.Repository;

namespace KyCMS.Common.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    public static class ElementRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public static IElementRepository DefaultRepository = new CacheElementRepository(new XmlElementRepository());
    }
}
