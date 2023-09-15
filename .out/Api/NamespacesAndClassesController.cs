using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class NamespacesAndClassesController : TenantManagerApiController
	{

		[HttpGet()]
		[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
		public HttpResponseMessage MyMethod(int id)
		{
			bool res = true;
			return Request.CreateResponse(HttpStatusCode.OK, res);
		}


	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (NamespacesAndClassBase namespacesAndClass)
  {

   NamespacesAndClassBaseRepository repo = new NamespacesAndClassBaseRepository();
   repo.Update(namespacesAndClass);
   return Request.CreateResponse(HttpStatusCode.OK, namespacesAndClass);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete ()
  {

   NamespacesAndClassBaseRepository repo = new NamespacesAndClassBaseRepository();
   repo.Delete(namespacesAndClass);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

