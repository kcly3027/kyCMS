using System;
using System.IO;
using Intelligencia.UrlRewriter;

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
                string filename = context.MapPath(context.Expand(_location));
                return File.Exists(filename) || Directory.Exists(filename);
            }
            catch
            {
                return false;
            }
        }

        private string _location;
    }
}
