using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
    public partial class NamespacesAndClassesController : ApiBrowserApiController
    {
        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
        public HttpResponseMessage List(bool classes, bool namespaces, string searchText, int pageIndex, int pageSize)
        {
            return Request.CreateResponse(HttpStatusCode.OK, NamespacesAndClassRepository.Instance.List(ApiBrowserModuleContext.ModuleContext.ModuleID, classes, namespaces, searchText, pageIndex, pageSize).Serialize());
        }
    }
}

