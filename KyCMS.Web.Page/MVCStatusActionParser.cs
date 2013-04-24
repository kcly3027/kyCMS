using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;
using Intelligencia.UrlRewriter;
using Intelligencia.UrlRewriter.Configuration;

namespace KyCMS.Web.MVC
{
    public class MVCStatusActionParser : IRewriteActionParser
    {
        #region Fields

        private HttpStatusCode _statusCode;

        #endregion

        #region .ctor

        public MVCStatusActionParser()
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

        public IRewriteAction Parse(XmlNode node, RewriterConfiguration config)
        {
            XmlNode statusCodeNode = node.Attributes.GetNamedItem("status");
            if (statusCodeNode == null)
            {
                return null;
            }
            return new MVCStatusAction((HttpStatusCode)Convert.ToInt32(statusCodeNode.Value));
        }

        #endregion

    }
}
