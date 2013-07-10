using System;
using System.Collections.Generic;

namespace KyCMS.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeExtensions
    {
        #region Fields
        readonly static List<Type> numericalTypes = new List<Type>(){            
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(float),
            typeof(long),
            typeof(double),
            typeof(decimal)
        }; 
        #endregion
        #region Methods
        /// <summary>
        /// Gets the type name without version.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string AssemblyQualifiedNameWithoutVersion(Type type)
        {
            string[] str = type.AssemblyQualifiedName.Split(',');
            return string.Format("{0},{1}", str[0], str[1]);
        }

        /// <summary>
        /// Gets all child types.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllChildTypes(Type type)
        {
            System.Reflection.Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<System.Reflection.Assembly> assemblies = new List<System.Reflection.Assembly>();
            foreach (System.Reflection.Assembly assembly in Assemblies)
            {
                if (!assembly.GlobalAssemblyCache)
                {
                    assemblies.Add(assembly);
                }
            }

            List<Type> types = new List<Type>();
            foreach (System.Reflection.Assembly assembly in assemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes());
                }
                catch { }
            }

            List<Type> targetTypes = new List<Type>();
            foreach (Type p in types)
            {
                if(type.IsAssignableFrom(p) && type != p){
                    targetTypes.Add(p);
                }
            }
            return targetTypes;
        }


        /// <summary>
        /// Determines whether [is numerical type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if [is numerical type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumericalType(Type type)
        {
            return numericalTypes.Contains(type);
        }

        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public static object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
            {
                return Activator.CreateInstance(t);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

