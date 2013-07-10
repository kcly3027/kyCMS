using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public interface IControllerFactory
    {
        IController CreateController(RequestContext context, string controllerName);
    }
}
