using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class SearchController: ApiBrowserMvcController
    {
        [HttpGet]
        [ApiBrowserMvcAuthorize(SecurityLevel = SecurityAccessLevel.View)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
