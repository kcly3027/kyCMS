using System;
using System.IO;
using System.Xml;
using Intelligencia.UrlRewriter;
using Intelligencia.UrlRewriter.Configuration;

namespace KyCMS.Web.MVC
{
    public class DynamicMappingConditionParser : IRewriteConditionParser
    {

        #region .ctor

        public DynamicMappingConditionParser()
        {
        }

        #endregion

        #region Properties

        public bool AllowsNestedActions
        {
            get
            {
                return false;
            }
        }

        public bool AllowsAttributes
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get { return "MyMVCAction"; }
        }

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
