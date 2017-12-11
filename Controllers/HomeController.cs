using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class HomeController: ApiBrowserMvcController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(ApiBrowserModuleContext.Settings.View);
        }
    }
}
