using System;
using System.Globalization;

namespace KyCMS.Common.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    public static class LocalizeExtension
    {
        #region Methods
        /// <summary>
        /// Localizes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string Localize(string source, CultureInfo culture)
        {
            return Localize(source, null, culture);

        }

        /// <summary>
        /// Localizes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public static string Localize(string source, string category)
        {
            return Localize(source, category, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

        /// <summary>
        /// Localizes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string Localize(string source, string category, CultureInfo culture)
        {
            return Map(source, source, category, culture).Value;
        }

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public static Element Map(string source, string key, string category = "")
        {
            return Map(source, key, category, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static Element Map(string source, string key, string category, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(key) || key.Trim() == string.Empty)
            {
                return Element.Empty;
            }

            var repository = ElementRepository.DefaultRepository;

            var element = repository.Get(key, category, culture.Name);
            if (element == null)
            {
                element = new Element() { Name = source, Category = category, Culture = culture.Name, Value = source };

                repository.Add(element);
            }
            return element;
        }

        /// <summary>
        /// Localizes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static string Localize(Element element)
        {
            return Map(element.Value,element.Name, element.Category, CultureInfo.GetCultureInfo(element.Culture)).Value;
        }

        /// <summary>
        /// Positions the specified STR.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public static string Position(string str, string position)
        {
            return String.Format("<span title=\"{1}\">{0}</span>", str, position);
        }
        #endregion
    }
}
