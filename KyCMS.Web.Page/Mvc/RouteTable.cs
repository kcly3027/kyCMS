using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public class RouteTable
    {
        public static RouteDictionary Routes { get; private set; }
        static RouteTable()
        {
            Routes = new RouteDictionary();
        }
    }
}
