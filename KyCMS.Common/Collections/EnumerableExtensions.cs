using System;
using System.Collections.Generic;

namespace KyCMS.Common.Collections
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumerableExtensions
    {
        #region Methods
        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static int IndexOf<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            int i = 0;
            foreach (T each in source)
            {
                if (predicate(each))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <returns>
        /// The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.
        /// </returns>
        public static int IndexOf<TSource>(IEnumerable<TSource> list, TSource value) where TSource : IEquatable<TSource>
        {
            int i = 0;
            foreach (TSource each in list)
            {
                if (each.Equals(value))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using a specified IEqualityComparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.
        /// </returns>
        public static int IndexOf<TSource>(IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer)
        {
            int index = 0;
            foreach (TSource item in list)
            {
                if (comparer.Equals(item, value))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }


        /// <summary>
        /// Compares the specified origianl.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origianl">The origianl.</param>
        /// <param name="current">The current.</param>
        /// <param name="match">The match.</param>
        /// <param name="update">The update.</param>
        /// <returns></returns>
        public static ComparedResult<T> Compare<T>(IEnumerable<T> origianl, IEnumerable<T> current, EnumerableMatchCallback<T> match, EnumerableUpdateCallback<T, T> update)
        {
            ComparedResult<T> result = new ComparedResult<T>();

            foreach (T o in origianl)//filter deleted object,update object
            {
                object find = match(current, o);

                if (find == null)//it should be removed from original collection
                {
                    result.Deleted.Add(o);
                }
                else //it should be updated with latest object
                {
                    if (update != null)
                    {
                        update(o, (T)find);
                    }

                    result.Updated.Add(o);
                }

            }

            foreach (T c in current)
            {
                object find = match(current, c);
                if (find == null)//filter added object
                {
                    result.Added.Add(c);
                }
            }

            return result;
        }
        #endregion

        public delegate bool EnumerableMatchCallback();
    }

    #region Callback
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args">The args.</param>
    public delegate object EnumerableMatchCallback<T>(IEnumerable<T> current, object value);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args">The args.</param>
    public delegate object EnumerableUpdateCallback<T1, T2>(T1 t1, T2 t2);

    #endregion
}
