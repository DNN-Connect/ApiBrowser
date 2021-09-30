using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class FilesController : ApiBrowserMvcController
    {
        [HttpGet]
        [ApiBrowserMvcAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public ActionResult Upload()
        {
            return View();
        }
    }
}
