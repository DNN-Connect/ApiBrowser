using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class MembersController : TenantManagerApiController
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
  public HttpResponseMessage Get (int memberId)
  {

    MemberRepository repo = new MemberRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(memberId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (MemberBase member)
 {

  member.SetAddingUser(userId);
   MemberBaseRepository repo = new MemberBaseRepository();
   repo.Insert(member);
   return Request.CreateResponse(HttpStatusCode.OK, member);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (MemberBase member)
  {

   member.SetModifyingUser(userId);
   MemberBaseRepository repo = new MemberBaseRepository();
   repo.Update(member);
   return Request.CreateResponse(HttpStatusCode.OK, member);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int memberId)
  {

   MemberBaseRepository repo = new MemberBaseRepository();
   repo.Delete(member);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

