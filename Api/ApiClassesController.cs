using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{

    public partial class ApiClassesController : ApiBrowserApiController
    {

        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
        public HttpResponseMessage Members(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, MemberRepository.Instance.GetMembersByApiClass(id));
        }
        public class DescriptionDTO
        {
            public string Description { get; set; }
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Comment)]
        public HttpResponseMessage Description(int id, DescriptionDTO data)
        {
            var c = ApiClassRepository.Instance.GetApiClass(id);
            if (c != null)
            {
                if (ApiBrowserModuleContext.Security.CanModerate)
                {
                    c.PendingDescription = null;
                    c.Description = data.Description.Trim();
                    ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase(), UserInfo.UserID);
                }
                else
                {
                    if (string.IsNullOrEmpty(c.PendingDescription) || c.LastModifiedByUserID == UserInfo.UserID)
                    {
                        c.PendingDescription = data.Description.Trim();
                        ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase(), UserInfo.UserID);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, ApiClassRepository.Instance.GetApiClass(id));
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public HttpResponseMessage ApproveDescription(int id)
        {
            var c = ApiClassRepository.Instance.GetApiClass(id);
            if (c != null && !string.IsNullOrEmpty(c.PendingDescription))
            {
                c.Description = c.PendingDescription;
                c.PendingDescription = null;
                ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase(), UserInfo.UserID);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

