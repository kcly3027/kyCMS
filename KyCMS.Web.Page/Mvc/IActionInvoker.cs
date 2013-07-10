using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext context, string actionName);
    }
}
