using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class ReferencesController : TenantManagerApiController
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
  public HttpResponseMessage Get (int referenceId)
  {

    ReferenceRepository repo = new ReferenceRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(referenceId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (ReferenceBase reference)
 {
   ReferenceBaseRepository repo = new ReferenceBaseRepository();
   repo.Insert(reference);
   return Request.CreateResponse(HttpStatusCode.OK, reference);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (ReferenceBase reference)
  {

   ReferenceBaseRepository repo = new ReferenceBaseRepository();
   repo.Update(reference);
   return Request.CreateResponse(HttpStatusCode.OK, reference);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int referenceId)
  {

   ReferenceBaseRepository repo = new ReferenceBaseRepository();
   repo.Delete(reference);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

