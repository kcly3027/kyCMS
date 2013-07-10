using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public IModelBinder ModelBinder { get; private set; }
        public ControllerActionInvoker()
        {
            this.ModelBinder = new DefaultModelBinder();
        }

        public void InvokeAction(ControllerContext context, string actionName)
        {
            MethodInfo method = GetFirstMemberInfo(context.Controller.GetType().GetMethods(), actionName);
            List<object> parameters = new List<object>();
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                parameters.Add(this.ModelBinder.BindModel(context, parameter.Name, parameter.ParameterType));
            }

            ActionResult actionResult = method.Invoke(context.Controller, parameters.ToArray()) as ActionResult;
            actionResult.ExecuteResult(context);
        }

        private MethodInfo GetFirstMemberInfo(MethodInfo[] array, string actionName)
        {
            foreach (MethodInfo info in array)
            {
                if (string.Compare(actionName, info.Name, true) == 0)
                    return info;
            }
            return null;
        }
    }
}
