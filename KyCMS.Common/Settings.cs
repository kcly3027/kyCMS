using System;
using System.Collections.Generic;
using System.Text;
using KyCMS.Common.Extensions;
namespace KyCMS.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Settings
    {

        /// <summary>
        /// Gets the base directory.
        /// </summary>
        /// <value>
        /// The base directory.
        /// </value>
        public static string BaseDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            }
        }
        /// <summary>
        /// Gets the bin directory.
        /// </summary>
        /// <value>
        /// The bin directory.
        /// </value>
        public static string BinDirectory
        {
            get
            {
                if (IsWebApplication)
                {
                    return AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
                }
                else
                {
                    return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                }
            }
        }
        /// <summary>
        /// Gets the components directory.
        /// </summary>
        /// <value>
        /// The components directory.
        /// </value>
        public static string ComponentsDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Components";
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is web application.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is web application; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWebApplication
        {
            get
            {
                return StringExtensions.EqualsOrNullEmpty(System.IO.Path.GetFileName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile), "Web.config", StringComparison.OrdinalIgnoreCase);
            }
        }
    }


}
