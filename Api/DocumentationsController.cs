using System.Net;
using System.Net.Http;
using System.Web.Http;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Models.Documentations;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
    public partial class DocumentationsController : ApiBrowserApiController
    {
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Comment)]
        public HttpResponseMessage Save(Documentation data)
        {
            var doc = data.DocumentationId == -1 ? new Documentation()
            {
                ClassId = data.ClassId,
                MemberId = data.MemberId
            } : DocumentationRepository.Instance.GetDocumentation(data.DocumentationId);
            if (doc.DocumentationId != -1 && !ApiBrowserModuleContext.Security.CanModerate)
            {
                if (doc.CreatedByUserID != UserInfo.UserID || doc.IsCurrentVersion)
                {
                    return ServiceError("Not allowed");
                }
            }
            var db = doc.GetDocumentationBase();
            db.Contents = data.Contents;
            if (db.DocumentationId == -1)
            {
                DocumentationRepository.Instance.AddDocumentation(ref db, UserInfo.UserID);
            }
            else
            {
                DocumentationRepository.Instance.UpdateDocumentation(db, UserInfo.UserID);
            }
            return Request.CreateResponse(HttpStatusCode.OK, DocumentationRepository.Instance.GetDocumentation(db.DocumentationId));
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public HttpResponseMessage SetCurrent(int id)
        {
            var doc = DocumentationRepository.Instance.GetDocumentation(id);
            if (doc.ClassId == -1)
            {
                var m = MemberRepository.Instance.GetMember(doc.MemberId);
                m.DocumentationId = doc.DocumentationId;
                MemberRepository.Instance.UpdateMember(m.GetMemberBase());
            }
            else
            {
                var c = ApiClassRepository.Instance.GetApiClass(doc.ClassId);
                c.DocumentationId = doc.DocumentationId;
                ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase());
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Comment)]
        public HttpResponseMessage Delete(int id)
        {
            var doc = DocumentationRepository.Instance.GetDocumentation(id);
            if (doc.DocumentationId != -1 && !ApiBrowserModuleContext.Security.CanModerate)
            {
                if (doc.CreatedByUserID != UserInfo.UserID || doc.IsCurrentVersion)
                {
                    return ServiceError("Not allowed");
                }
            }
            DocumentationRepository.Instance.DeleteDocumentation(id);
            if (doc.IsCurrentVersion)
            {
                if (doc.ClassId == -1)
                {
                    var m = MemberRepository.Instance.GetMember(doc.MemberId);
                    m.DocumentationId = -1;
                    MemberRepository.Instance.UpdateMember(m.GetMemberBase());
                }
                else
                {
                    var c = ApiClassRepository.Instance.GetApiClass(doc.ClassId);
                    c.DocumentationId = -1;
                    ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase());
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

