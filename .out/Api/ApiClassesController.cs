using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class ApiClassesController : TenantManagerApiController
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
  public HttpResponseMessage Get (int classId)
  {

    ApiClassRepository repo = new ApiClassRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(classId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (ApiClassBase apiClass)
 {

  apiClass.SetAddingUser(userId);
   ApiClassBaseRepository repo = new ApiClassBaseRepository();
   repo.Insert(apiClass);
   return Request.CreateResponse(HttpStatusCode.OK, apiClass);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (ApiClassBase apiClass)
  {

   apiClass.SetModifyingUser(userId);
   ApiClassBaseRepository repo = new ApiClassBaseRepository();
   repo.Update(apiClass);
   return Request.CreateResponse(HttpStatusCode.OK, apiClass);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int classId)
  {

   ApiClassBaseRepository repo = new ApiClassBaseRepository();
   repo.Delete(apiClass);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

