using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace KyCMS.Web.MVC.Mvc
{
    public class RequestContext
    {
        public virtual RequestMethod RequestMethod { get; set; }
        public virtual HttpContext HttpContext { get; set; }
        public virtual RouteData RouteData { get; set; }
    }
}
