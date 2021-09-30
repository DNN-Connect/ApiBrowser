using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
    public partial class NamespacesClassesAndMembersController : ApiBrowserApiController
    {
        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
        public HttpResponseMessage List(int mainType, int subType, int status, string searchText, int pageIndex, int pageSize)
        {
            return Request.CreateResponse(HttpStatusCode.OK, NamespacesClassesAndMemberRepository.Instance.List(ApiBrowserModuleContext.ModuleContext.ModuleID, mainType, subType, status, searchText, pageIndex, pageSize).Serialize());
        }
    }
}

