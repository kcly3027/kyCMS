using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace KyCMS.Web.MVC.Mvc
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}
