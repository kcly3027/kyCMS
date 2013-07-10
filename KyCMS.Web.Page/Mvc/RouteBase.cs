using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace KyCMS.Web.MVC.Mvc
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContext context);
    }
}
