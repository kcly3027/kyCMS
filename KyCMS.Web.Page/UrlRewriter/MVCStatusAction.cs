using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Intelligencia.UrlRewriter;

namespace KyCMS.Web.MVC.UrlRewriter
{
    public class MVCStatusAction : IRewriteAction
    {
        #region Fields

        private HttpStatusCode _statusCode;

        #endregion

        #region .ctor

        public MVCStatusAction(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        #endregion

        #region Properties

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        public RewriteProcessing Processing
        {
            get {
                if ((int)StatusCode >= 300)
                {
                    return RewriteProcessing.StopProcessing;
                }
                else
                {
                    return RewriteProcessing.ContinueProcessing;
                }
            }
        }

        #endregion

        #region Methods

        public RewriteProcessing Execute(RewriteContext context)
        {
            context.StatusCode = StatusCode;
            return Processing;
        }

        #endregion
    }
}
