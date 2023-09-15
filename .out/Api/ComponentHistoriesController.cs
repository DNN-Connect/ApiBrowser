using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class ComponentHistoriesController : TenantManagerApiController
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
  public HttpResponseMessage Get (int componentHistoryId)
  {

    ComponentHistoryRepository repo = new ComponentHistoryRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(componentHistoryId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (ComponentHistoryBase componentHistory)
 {
   ComponentHistoryBaseRepository repo = new ComponentHistoryBaseRepository();
   repo.Insert(componentHistory);
   return Request.CreateResponse(HttpStatusCode.OK, componentHistory);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (ComponentHistoryBase componentHistory)
  {

   ComponentHistoryBaseRepository repo = new ComponentHistoryBaseRepository();
   repo.Update(componentHistory);
   return Request.CreateResponse(HttpStatusCode.OK, componentHistory);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int componentHistoryId)
  {

   ComponentHistoryBaseRepository repo = new ComponentHistoryBaseRepository();
   repo.Delete(componentHistory);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

