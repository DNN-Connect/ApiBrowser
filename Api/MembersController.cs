using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
    public partial class MembersController : ApiBrowserApiController
    {
        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
        public HttpResponseMessage CodeBlocks(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, MemberCodeBlockRepository.Instance.GetMemberCodeBlocksByMember(id).OrderBy(cb => cb.Version));
        }
        public class DescriptionDTO
        {
            public string Description { get; set; }
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Comment)]
        public HttpResponseMessage Description(int id, DescriptionDTO data)
        {
            var m = MemberRepository.Instance.GetMember(id);
            if (m != null)
            {
                if (ApiBrowserModuleContext.Security.CanModerate)
                {
                    m.PendingDescription = null;
                    m.Description = data.Description.Trim();
                    MemberRepository.Instance.UpdateMember(m.GetMemberBase(), UserInfo.UserID);
                }
                else
                {
                    if (string.IsNullOrEmpty(m.PendingDescription) || m.LastModifiedByUserID == UserInfo.UserID)
                    {
                        m.PendingDescription = data.Description.Trim();
                        MemberRepository.Instance.UpdateMember(m.GetMemberBase(), UserInfo.UserID);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, MemberRepository.Instance.GetMember(id));
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public HttpResponseMessage ApproveDescription(int id)
        {
            var m = MemberRepository.Instance.GetMember(id);
            if (m != null && !string.IsNullOrEmpty(m.PendingDescription))
            {
                m.Description = m.PendingDescription;
                m.PendingDescription = null;
                MemberRepository.Instance.UpdateMember(m.GetMemberBase(), UserInfo.UserID);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public HttpResponseMessage RejectDescription(int id)
        {
            var m = MemberRepository.Instance.GetMember(id);
            if (m != null && !string.IsNullOrEmpty(m.PendingDescription))
            {
                m.PendingDescription = null;
                MemberRepository.Instance.UpdateMember(m.GetMemberBase(), UserInfo.UserID);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

