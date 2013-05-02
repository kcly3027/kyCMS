using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Common
{
    public class TypeActivator
    {
        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
