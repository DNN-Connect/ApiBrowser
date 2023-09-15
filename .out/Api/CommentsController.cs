using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class CommentsController : TenantManagerApiController
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
  public HttpResponseMessage Get (int commentID)
  {

    CommentRepository repo = new CommentRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(commentID));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (CommentBase comment)
 {

  comment.SetAddingUser(userId);
   CommentBaseRepository repo = new CommentBaseRepository();
   repo.Insert(comment);
   return Request.CreateResponse(HttpStatusCode.OK, comment);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (CommentBase comment)
  {

   comment.SetModifyingUser(userId);
   CommentBaseRepository repo = new CommentBaseRepository();
   repo.Update(comment);
   return Request.CreateResponse(HttpStatusCode.OK, comment);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int commentID)
  {

   CommentBaseRepository repo = new CommentBaseRepository();
   repo.Delete(comment);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

