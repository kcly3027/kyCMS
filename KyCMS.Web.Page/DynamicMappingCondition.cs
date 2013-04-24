using System;
using System.IO;
using Intelligencia.UrlRewriter;

namespace KyCMS.Web.MVC
{
    public class DynamicMappingCondition : IRewriteCondition
    {
        public DynamicMappingCondition(string location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }
            _location = location;
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
