﻿using System.Collections.Generic;
using System.Globalization;

namespace KyCMS.Common.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    public class ElementCategory
    {
        #region Properties

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public string Culture { get; set; }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IElementRepository
    {
        #region Methods
        /// <summary>
        /// Enableds the languages.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CultureInfo> EnabledLanguages();

        /// <summary>
        /// Elementses this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Element> Elements();

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        Element Get(string name, string category, string culture);

        /// <summary>
        /// Categorieses this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ElementCategory> Categories();

        /// <summary>
        /// Adds the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        bool Add(Element element);

        /// <summary>
        /// Updates the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        bool Update(Element element);

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        bool Remove(Element element);

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        void AddCategory(string category, string culture);

        /// <summary>
        /// Removes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        bool RemoveCategory(string category, string culture);
        #endregion
    }
}
