using System;
using System.IO;
using System.Web;
using Intelligencia.UrlRewriter;
using KyCMS.Web.MVC.Mvc;

namespace KyCMS.Web.MVC.UrlRewriter
{
    public class DynamicMappingCondition : IRewriteCondition
    {
        protected bool IsDynamicMapping = false;

        public DynamicMappingCondition(string isdynamicmapping)
        {
            if (isdynamicmapping == null)
            {
                throw new ArgumentNullException("dynamicmapping");
            }
            IsDynamicMapping = isdynamicmapping.ToLower() == "true";
        }

        public bool IsMatch(RewriteContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            try
            {
                if (IsDynamicMapping)
                {
                    RouteTable.Routes.Add("default", new Route { Url = "{controller}/{action}" });
                    ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory());
                    ControllerBuilder.Current.DefaultNamespaces.Add("KyCMS.Web");


                    RouteData routeData = RouteTable.Routes.GetRouteData(HttpContext.Current);
                    if (null == routeData)
                    {
                        return false;
                    }
                    RequestContext requestContext = new RequestContext { RouteData = routeData, HttpContext = HttpContext.Current };
                    IHttpHandler handler = routeData.RouteHandler.GetHttpHandler(requestContext);
                    HttpContext.Current.RemapHandler(handler);

                    //System.Web.HttpContext.Current.Response.Write(System.Web.HttpContext.Current.Request.Url + "<br/>");
                    //System.Web.HttpContext.Current.Response.Write(context.Method + "<br/>");
                    //System.Web.HttpContext.Current.Response.Write(context.Location + "<br/>");
                    //System.Web.HttpContext.Current.Response.Write(context.MapPath(context.Expand(context.Location)) + "<br/>");
                }
                /*
                string filename = context.MapPath(context.Expand(_location));
                return File.Exists(filename) || Directory.Exists(filename);
                */
                return IsDynamicMapping;
            }
            catch
            {
                return false;
            }
        }
    }
}
