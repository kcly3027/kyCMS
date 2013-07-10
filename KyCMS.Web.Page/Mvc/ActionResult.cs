using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(ControllerContext context);
    }
}
