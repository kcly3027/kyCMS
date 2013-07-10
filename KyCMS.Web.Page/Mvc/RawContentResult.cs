using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public class RawContentResult : ActionResult
    {
        public string RawData { get; private set; }
        public RawContentResult(string rawData)
        {
            RawData = rawData;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.Write(this.RawData);
        }
    }
}
