using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
	public partial class MembersController : ApiBrowserApiController
	{
		[HttpGet]
		[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
		public HttpResponseMessage CodeBlocks(int id)
		{
			return Request.CreateResponse(HttpStatusCode.OK, MemberCodeBlockRepository.Instance.GetMemberCodeBlocksByMember(id).OrderBy(cb => cb.Version));
		}
	}
}

