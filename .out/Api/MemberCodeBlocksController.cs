using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class MemberCodeBlocksController : TenantManagerApiController
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
  public HttpResponseMessage Get (int codeBlockId)
  {

    MemberCodeBlockRepository repo = new MemberCodeBlockRepository();
    return Request.CreateResponse(HttpStatusCode.OK, repo.GetById(codeBlockId));

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Add (MemberCodeBlockBase memberCodeBlock)
 {
   MemberCodeBlockBaseRepository repo = new MemberCodeBlockBaseRepository();
   repo.Insert(memberCodeBlock);
   return Request.CreateResponse(HttpStatusCode.OK, memberCodeBlock);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Update (MemberCodeBlockBase memberCodeBlock)
  {

   MemberCodeBlockBaseRepository repo = new MemberCodeBlockBaseRepository();
   repo.Update(memberCodeBlock);
   return Request.CreateResponse(HttpStatusCode.OK, memberCodeBlock);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete (int codeBlockId)
  {

   MemberCodeBlockBaseRepository repo = new MemberCodeBlockBaseRepository();
   repo.Delete(memberCodeBlock);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

