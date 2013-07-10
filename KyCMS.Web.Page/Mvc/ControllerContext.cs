using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public class ControllerContext
    {
        public ControllerBase Controller { get; set; }
        public RequestContext RequestContext { get; set; }
    }
}
