using System.Net;
using System.Net.Http;
using System.Web.Http;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Models.Documentations;
using Connect.ApiBrowser.Core.Data;

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
                ModuleId = ApiBrowserModuleContext.ModuleContext.ModuleID,
                FullName = data.FullName
            } : DocumentationRepository.Instance.GetDocumentation(ActiveModule.ModuleID, data.DocumentationId);
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
            return Request.CreateResponse(HttpStatusCode.OK, DocumentationRepository.Instance.GetDocumentation(ActiveModule.ModuleID, db.DocumentationId));
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public HttpResponseMessage SetCurrent(int id)
        {
            var doc = DocumentationRepository.Instance.GetDocumentation(ActiveModule.ModuleID, id);
            var m = MemberRepository.Instance.GetMember(doc.ModuleId, doc.FullName);
            if (m != null)
            {
                m.DocumentationId = doc.DocumentationId;
                MemberRepository.Instance.UpdateMember(m.GetMemberBase(), UserInfo.UserID);
            }
            else
            {
                var c = ApiClassRepository.Instance.GetApiClass(doc.ModuleId, doc.FullName);
                if (c != null)
                {
                    c.DocumentationId = doc.DocumentationId;
                    ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase(), UserInfo.UserID);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Comment)]
        public HttpResponseMessage Delete(int id)
        {
            var doc = DocumentationRepository.Instance.GetDocumentation(ActiveModule.ModuleID, id);
            if (doc.DocumentationId != -1 && !ApiBrowserModuleContext.Security.CanModerate)
            {
                if (doc.CreatedByUserID != UserInfo.UserID || doc.IsCurrentVersion)
                {
                    return ServiceError("Not allowed");
                }
            }
            DocumentationRepository.Instance.DeleteDocumentation(ActiveModule.ModuleID, id);
            if (doc.IsCurrentVersion)
            {
                var m = MemberRepository.Instance.GetMember(doc.ModuleId, doc.FullName);
                if (m != null)
                {
                    m.DocumentationId = -1;
                    MemberRepository.Instance.UpdateMember(m.GetMemberBase(), UserInfo.UserID);
                }
                else
                {
                    var c = ApiClassRepository.Instance.GetApiClass(doc.ModuleId, doc.FullName);
                    if (c != null)
                    {
                        c.DocumentationId = -1;
                        ApiClassRepository.Instance.UpdateApiClass(c.GetApiClassBase(), UserInfo.UserID);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [ApiBrowserAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public HttpResponseMessage Moderation()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Sprocs.GetModerationList(ApiBrowserModuleContext.ModuleContext.ModuleID));
        }
    }
}

