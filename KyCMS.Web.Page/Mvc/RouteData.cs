﻿using System;
using System.Collections.Generic;
using System.Text;
using KyCMS.Common.Collections;

namespace KyCMS.Web.MVC.Mvc
{
    public class RouteData
    {
        public IDictionary<string, object> Values { get; set; }
        public IDictionary<string, object> DataTokens { get; set; }
        public IRouteHandler RouteHandler { get; set; }
        public RouteBase Route { get; set; }

        public RouteData()
        {
            this.Values = new CachableDictionary<string, object>();
            this.DataTokens = new CachableDictionary<string, object>();
            this.DataTokens.Add("namespaces",new List<string>());
        }

        public string Controller
        {
            get
            {
                object controllerName = string.Empty;
                this.Values.TryGetValue("controller", out controllerName);
                return controllerName.ToString();
            }
        }

        public string ActionName
        {
            get
            {
                object actionName = string.Empty;
                this.Values.TryGetValue("action", out actionName);
                return actionName.ToString();
            }
        }

        public IEnumerable<string> Namespaces
        {
            get
            {
                return (IEnumerable<string>)this.DataTokens["namespace"];
            }
        }
    }
}
