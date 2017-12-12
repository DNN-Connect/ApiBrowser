using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{

	public partial class ApiClassesController : ApiBrowserApiController
	{

		[HttpGet()]
		[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
		public HttpResponseMessage Members(int id)
		{
			return Request.CreateResponse(HttpStatusCode.OK, MemberRepository.Instance.GetMembersByApiClass(id));
		}

	}
}

