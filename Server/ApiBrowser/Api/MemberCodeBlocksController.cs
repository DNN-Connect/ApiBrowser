using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Models;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
	public partial class MemberCodeBlocksController : ApiBrowserApiController
	{
		[HttpGet]
		[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
		public HttpResponseMessage Get(int id)
		{
            CodeBlock res = null;
            var cb = MemberCodeBlockRepository.Instance.GetMemberCodeBlock(id);
            if (cb != null)
            {
                res = Connect.ApiBrowser.Core.Controllers.CodeBlocksController.GetCodeBlock(ApiBrowserModuleContext.ModuleContext.ModuleID, cb.CodeHash);
            }
			return Request.CreateResponse(HttpStatusCode.OK, res);
		}
	}
}

