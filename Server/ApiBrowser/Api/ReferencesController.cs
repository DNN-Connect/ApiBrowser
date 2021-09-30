using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
    public partial class ReferencesController : ApiBrowserApiController
    {
        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
        public HttpResponseMessage ToMember(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ReferenceRepository.Instance.GetReferencesToMember(id));
        }
        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
        public HttpResponseMessage FromBlock(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ReferenceRepository.Instance.GetReferencesByMemberCodeBlock(id));
        }
    }
}

