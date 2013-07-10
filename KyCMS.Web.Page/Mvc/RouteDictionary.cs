using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using KyCMS.Common.Collections;

namespace KyCMS.Web.MVC.Mvc
{
    public class RouteDictionary : CachableDictionary<string, RouteBase>
    {
        public RouteData GetRouteData(HttpContext context)
        {
            foreach (var route in this.Values)
            {
                RouteData routeData = route.GetRouteData(context);
                if (null != routeData)
                {
                    return routeData;
                }
            }
            return null;
        }
    }
}
