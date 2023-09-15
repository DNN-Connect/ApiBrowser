using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class DependenciesController : TenantManagerApiController
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
  public HttpResponseMessage Get (int dependencyId)
  {

    DependencyRepository repo = new DependencyRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(dependencyId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (DependencyBase dependency)
 {
   DependencyBaseRepository repo = new DependencyBaseRepository();
   repo.Insert(dependency);
   return Request.CreateResponse(HttpStatusCode.OK, dependency);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (DependencyBase dependency)
  {

   DependencyBaseRepository repo = new DependencyBaseRepository();
   repo.Update(dependency);
   return Request.CreateResponse(HttpStatusCode.OK, dependency);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int dependencyId)
  {

   DependencyBaseRepository repo = new DependencyBaseRepository();
   repo.Delete(dependency);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

