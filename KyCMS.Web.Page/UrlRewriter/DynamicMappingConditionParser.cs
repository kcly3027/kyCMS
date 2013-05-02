using System;
using System.IO;
using System.Xml;
using Intelligencia.UrlRewriter;
using Intelligencia.UrlRewriter.Configuration;

namespace KyCMS.Web.MVC.UrlRewriter
{
    public class DynamicMappingConditionParser : IRewriteConditionParser
    {

        #region .ctor

        public DynamicMappingConditionParser()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        public IRewriteCondition Parse(XmlNode node)
        {
            XmlNode dynamicmapping = node.Attributes.GetNamedItem("dynamicmapping");
            if (dynamicmapping == null)
            {
                return null;
            }
            return new DynamicMappingCondition(dynamicmapping.Value);
        }

        #endregion
    }
}
