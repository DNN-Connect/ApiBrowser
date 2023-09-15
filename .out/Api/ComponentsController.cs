using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class ComponentsController : TenantManagerApiController
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
  public HttpResponseMessage Get (int componentId)
  {

    ComponentRepository repo = new ComponentRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(componentId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (ComponentBase component)
 {
   ComponentBaseRepository repo = new ComponentBaseRepository();
   repo.Insert(component);
   return Request.CreateResponse(HttpStatusCode.OK, component);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (ComponentBase component)
  {

   ComponentBaseRepository repo = new ComponentBaseRepository();
   repo.Update(component);
   return Request.CreateResponse(HttpStatusCode.OK, component);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int componentId)
  {

   ComponentBaseRepository repo = new ComponentBaseRepository();
   repo.Delete(component);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

