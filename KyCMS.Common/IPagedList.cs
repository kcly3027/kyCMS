﻿using System.Collections.Generic;
namespace KyCMS.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets the index of the current page.
        /// </summary>
        /// <value>
        /// The index of the current page.
        /// </value>
        int CurrentPageIndex { get; set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the total item count.
        /// </summary>
        int TotalItemCount { get; set; }
        /// <summary>
        /// Gets the total page count.
        /// </summary>
        /// <value>
        /// The total page count.
        /// </value>
        int TotalPageCount { get; }
        /// <summary>
        /// Gets the start index of the record.
        /// </summary>
        /// <value>
        /// The start index of the record.
        /// </value>
        int StartRecordIndex { get; }
        /// <summary>
        /// Gets the end index of the record.
        /// </summary>
        /// <value>
        /// The end index of the record.
        /// </value>
        int EndRecordIndex { get; }
    }
}
