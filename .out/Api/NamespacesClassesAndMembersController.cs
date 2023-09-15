using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.TenantManager.Common;

namespace Connect.ApiBrowser.Core.Api
{

	public partial class NamespacesClassesAndMembersController : TenantManagerApiController
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
  public HttpResponseMessage Update (NamespacesClassesAndMemberBase namespacesClassesAndMember)
  {

   NamespacesClassesAndMemberBaseRepository repo = new NamespacesClassesAndMemberBaseRepository();
   repo.Update(namespacesClassesAndMember);
   return Request.CreateResponse(HttpStatusCode.OK, namespacesClassesAndMember);

  }

	[HttpPost]
	[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  public HttpResponseMessage Delete ()
  {

   NamespacesClassesAndMemberBaseRepository repo = new NamespacesClassesAndMemberBaseRepository();
   repo.Delete(namespacesClassesAndMember);
   return Request.CreateResponse(HttpStatusCode.OK, "");

  }

	}
}

