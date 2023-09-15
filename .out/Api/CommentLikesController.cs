using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class CommentLikesController : TenantManagerApiController
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
  public HttpResponseMessage Update (CommentLikeBase commentLike)
  {

   CommentLikeBaseRepository repo = new CommentLikeBaseRepository();
   repo.Update(commentLike);
   return Request.CreateResponse(HttpStatusCode.OK, commentLike);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int commentId, int userId)
  {

   CommentLikeBaseRepository repo = new CommentLikeBaseRepository();
   repo.Delete(commentLike);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

