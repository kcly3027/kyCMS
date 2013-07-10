using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.Compilation;
using LinqBridge.Linq;

namespace KyCMS.Web.MVC.Mvc
{
    public class DefaultControllerFactory : IControllerFactory
    {
        private List<Type> controllerTypes = new List<Type>();
        public DefaultControllerFactory()
        {
            foreach (Assembly assembly in BuildManager.GetReferencedAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IController).IsAssignableFrom(type))
                    {
                        controllerTypes.Add(type);
                    }
                }
            }
        }

        public IController CreateController(RequestContext context, string controllerName)
        {
            string typeName = controllerName + "Controller";
            List<string> namespaces = new List<string>();
            namespaces.AddRange(context.RouteData.Namespaces);
            namespaces.AddRange(ControllerBuilder.Current.DefaultNamespaces);
            foreach (string ns in namespaces)
            {
                string controllTypeName = string.Format("{0}.{1}", ns, typeName);
                Type controllerType = null;
                foreach (Type type in controllerTypes)
                {
                    if (string.Compare(type.FullName, controllTypeName, true) == 0)
                    {
                        controllerType = type;
                        break;
                    }
                }
                if (null != controllerType)
                {
                    return (IController)Activator.CreateInstance(controllerType);
                }
            }
            return null;
        }
    }
}
