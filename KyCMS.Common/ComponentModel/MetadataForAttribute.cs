﻿using System;

namespace KyCMS.Common.ComponentModel
{
    /// <summary>
    /// Indicate reverse mapping from meta data type to data type, it's used in meta data type class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class MetadataForAttribute : Attribute
    {
        #region .ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataForAttribute" /> class.
        /// </summary>
        /// <param name="type">The type current type describe meta data for.</param>
        public MetadataForAttribute(Type type)
        {
            Type = type;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the type current type describe meta data for.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; private set; }
        #endregion
    }
}
