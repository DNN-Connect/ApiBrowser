using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using System.IO;
using System.IO.Compression;
using DotNetNuke.Web.Api;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class FilesController : ApiBrowserMvcController
    {
        [HttpGet]
        [DnnModuleAuthorize(PermissionKey = "Edit")]
        public ActionResult Upload()
        {
            return View();
        }
    }
}
