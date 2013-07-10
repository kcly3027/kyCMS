using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace KyCMS.Web.MVC.Mvc
{
    public class MvcHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public RequestContext RequestContext { get; private set; }
        public MvcHandler(RequestContext context)
        {
            this.RequestContext = context;
        }
        public void ProcessRequest(HttpContext context)
        {
            string controllName = this.RequestContext.RouteData.Controller;

        }
    }
}
