using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public abstract class ControllerBase : IController
    {
        protected IActionInvoker ActionInvoker { get; set; }
        public ControllerBase()
        {
            this.ActionInvoker = new ControllerActionInvoker();
        }
        public void Execute(RequestContext context)
        {
            ControllerContext controllerContext = new ControllerContext();
            controllerContext.RequestContext = context;
            controllerContext.Controller = this;

            string actionName = context.RouteData.ActionName;
            this.ActionInvoker.InvokeAction(controllerContext, actionName);
        }
    }
}
