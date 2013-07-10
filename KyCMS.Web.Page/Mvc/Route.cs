using System;
using System.Collections.Generic;
using System.Text;
using KyCMS.Common.Collections;

namespace KyCMS.Web.MVC.Mvc
{
    public class Route : RouteBase
    {
        public IRouteHandler RouteHandler { get; set; }
        public string Url { get; set; }
        public IDictionary<string, object> DataTokens { get; set; }
        public Route()
        {
            this.DataTokens = new CachableDictionary<string, object>();
            this.RouteHandler = new MvcRouteHandler();
        }

        public override RouteData GetRouteData(System.Web.HttpContext context)
        {
            IDictionary<string, object> variables;
            if (this.Match(context.Request.AppRelativeCurrentExecutionFilePath.Substring(2), out variables))
            {
                RouteData routeData = new RouteData();
                foreach (KeyValuePair<string, object> kvp in variables)
                {
                    routeData.Values.Add(kvp.Key, kvp.Value);
                }
                foreach (KeyValuePair<string, object> kvp in DataTokens)
                {
                    routeData.DataTokens.Add(kvp.Key, kvp.Value);
                }
                routeData.RouteHandler = this.RouteHandler;
                return routeData;
            }
            return null;
        }

        protected bool Match(string requestUrl, out IDictionary<string, object> variables)
        {
            variables = new CachableDictionary<string, object>();
            string[] strArray1 = requestUrl.Split('/');
            string[] strArray2 = this.Url.Split('/');
            if (strArray1.Length != strArray2.Length)
            {
                return false;
            }

            for (int i = 0; i < strArray2.Length; i++)
            {
                if (strArray2[i].StartsWith("{") && strArray2[i].EndsWith("}"))
                {
                    variables.Add(strArray2[i].Trim("{}".ToCharArray()), strArray1[i]);
                }
            }
            return true;

        }
    }
}
