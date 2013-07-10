using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class KyCMSException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KoobooException" /> class.
        /// </summary>
        public KyCMSException()
            : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="KoobooException" /> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public KyCMSException(string msg)
            : base(msg)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="KoobooException" /> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="exception">The exception.</param>
        public KyCMSException(string msg, Exception exception)
            : base(msg, exception)
        { }
    }
}
