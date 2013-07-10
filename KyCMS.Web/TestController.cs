using System;
using System.Collections.Generic;
using System.Web;
using KyCMS.Web.MVC.Mvc;

namespace KyCMS.Web
{
    public class TestController : ControllerBase
    {
        public ActionResult Index()
        {
            return new RawContentResult("这是测试页面");
        }
    }
}