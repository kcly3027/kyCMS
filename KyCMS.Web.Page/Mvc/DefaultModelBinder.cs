using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using System.Web;
using KyCMS.Common.Extensions;

namespace KyCMS.Web.MVC.Mvc
{
    public class DefaultModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext context, string modelName, Type modelType)
        {
            if (modelType.IsValueType || typeof(string) == modelType)
            {
                object instance;
                if (GetValueTypeInstance(context, modelName, modelType, out instance))
                {
                    return instance;
                }
                return Activator.CreateInstance(modelType);
            }

            object modelInstance = Activator.CreateInstance(modelType);
            foreach (PropertyInfo property in modelType.GetProperties())
            {
                if (!property.CanWrite || (!property.PropertyType.IsValueType && property.PropertyType != typeof(string)))
                {
                    continue;
                }
                object propertyValue;
                if (GetValueTypeInstance(context, property.Name, property.PropertyType, out propertyValue))
                {
                    property.SetValue(modelInstance, propertyValue, null);
                }
            }
            return modelInstance;
        }

        private bool GetValueTypeInstance(ControllerContext context, string modelName, Type modelType, out object value)
        {
            NameValueCollection form = HttpContext.Current.Request.Form;
            string key;
            if (null != form)
            {
                key = ArrayFirstOrDefault(form.AllKeys, modelName);
                if (key != null)
                {
                    value = Convert.ChangeType(form[key], modelType);
                    return true;
                }
            }

            key = DictionaryFirstOrDefault(context.RequestContext.RouteData.Values, modelName);
            if (null != key)
            {
                value = Convert.ChangeType(context.RequestContext.RouteData.DataTokens[key], modelType);
                return true;
            }
            value = null;
            return false;
        }

        //private T ArrayFirstOrDefault<T>(T[] TArray, T TKey) where T : IComparable
        //{
        //    foreach (T t in TArray)
        //    {
        //        if (t.CompareTo(TKey) == 0) return t;
        //    }
        //    return default(T);
        //}

        private string ArrayFirstOrDefault(string[] strArray, string modelName)
        {
            foreach (string item in strArray)
            {
                if (string.Compare(item, modelName, true) == 0)
                    return item;
            }
            return null;
        }
        private string DictionaryFirstOrDefault(IDictionary<string,object> dicts, string modelName)
        {
            foreach (KeyValuePair<string,object> item in dicts)
            {
                if (string.Compare(item.Key, modelName, true) == 0)
                    return item.Key;
            }
            return null;
        }
    }
}
