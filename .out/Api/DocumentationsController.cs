using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class DocumentationsController : TenantManagerApiController
	{

		[HttpGet()]
		[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
		public HttpResponseMessage MyMethod(int id)
		{
			bool res = true;
			return Request.CreateResponse(HttpStatusCode.OK, res);
		}

	[HttpGet]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
  public HttpResponseMessage Get (int documentationId)
  {

    DocumentationRepository repo = new DocumentationRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(documentationId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (DocumentationBase documentation)
 {

  documentation.SetAddingUser(userId);
   DocumentationBaseRepository repo = new DocumentationBaseRepository();
   repo.Insert(documentation);
   return Request.CreateResponse(HttpStatusCode.OK, documentation);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (DocumentationBase documentation)
  {

   documentation.SetModifyingUser(userId);
   DocumentationBaseRepository repo = new DocumentationBaseRepository();
   repo.Update(documentation);
   return Request.CreateResponse(HttpStatusCode.OK, documentation);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int documentationId)
  {

   DocumentationBaseRepository repo = new DocumentationBaseRepository();
   repo.Delete(documentation);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

