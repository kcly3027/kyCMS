#region License
// 
// Copyright (c) 2013, KyCMS.Common team
// 
// Licensed under the BSD License
// See the file LICENSE.txt for details.
// 
#endregion
using System.Drawing;
using System.Windows.Forms;

namespace KyCMS.Common.Drawing
{
    /// <summary>
    /// 
    /// </summary>
    public static class ColorExtensions
    {
        #region Methods
        /// <summary>        
        /// 让颜色变淡一些
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Color Light(Color color)
        {
            return ControlPaint.Light(color);
        }
        /// <summary>
        /// Darks the specified color.
        /// 让颜色变深一些
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Color Dark(Color color)
        {
            return ControlPaint.Dark(color);
        } 
        #endregion
    }
}
