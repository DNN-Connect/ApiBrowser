using DotNetNuke.Web.Api;
using System.Net;
using System.Net.Http;

namespace Connect.DNN.Modules.ApiBrowser.Common
{
    public class ApiBrowserApiController : DnnApiController
    {
        private ContextHelper _apibrowserModuleContext;
        public ContextHelper ApiBrowserModuleContext
        {
            get { return _apibrowserModuleContext ?? (_apibrowserModuleContext = new ContextHelper(this)); }
        }

        public HttpResponseMessage ServiceError(string message) {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, message);
        }

        public HttpResponseMessage AccessViolation(string message)
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized, message);
        }

    }
}