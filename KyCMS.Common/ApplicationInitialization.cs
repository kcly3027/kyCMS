using System;
using System.Collections.Generic;

namespace KyCMS.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationInitialization
    {
        public delegate void InitializeMethod();
        #region Fields
        private class InitializationItem
        {

            public InitializeMethod CallBack { get; set; }
            public int Priority { get; set; }
        }
        private static List<InitializationItem> items = new List<InitializationItem>(); 
        #endregion

        #region Methods

        private static int Compare(InitializationItem x, InitializationItem y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.Priority > y.Priority ? x.Priority : y.Priority;
                }
            }
        }

        /// <summary>
        /// Registers the initializer method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="priority">The priority.</param>
        public static void RegisterInitializerMethod(InitializeMethod method, int priority)
        {
            items.Add(new InitializationItem() { CallBack = method, Priority = priority });
        }
        /// <summary>
        /// Executes this instance.
        /// </summary>
        public static void Execute()
        {
            lock (items)
            {
                items.Sort(Compare);
                foreach (InitializationItem item in items)
                {
                    item.CallBack();
                }
                items.Clear();
            }

        } 
        #endregion
    }
}
