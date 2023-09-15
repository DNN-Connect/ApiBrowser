using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class ApiNamespacesController : TenantManagerApiController
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
  public HttpResponseMessage Get (int namespaceId)
  {

    ApiNamespaceRepository repo = new ApiNamespaceRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(namespaceId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (ApiNamespaceBase apiNamespace)
 {
   ApiNamespaceBaseRepository repo = new ApiNamespaceBaseRepository();
   repo.Insert(apiNamespace);
   return Request.CreateResponse(HttpStatusCode.OK, apiNamespace);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (ApiNamespaceBase apiNamespace)
  {

   ApiNamespaceBaseRepository repo = new ApiNamespaceBaseRepository();
   repo.Update(apiNamespace);
   return Request.CreateResponse(HttpStatusCode.OK, apiNamespace);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int namespaceId)
  {

   ApiNamespaceBaseRepository repo = new ApiNamespaceBaseRepository();
   repo.Delete(apiNamespace);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

