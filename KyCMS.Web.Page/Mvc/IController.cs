using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public interface IController
    {
        void Execute(RequestContext context);
    }
}
