using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace KyCMS.Web.MVC.Mvc
{
    public class MvcRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext context)
        {
            return new MvcHandler(context);
        }
    }
}
