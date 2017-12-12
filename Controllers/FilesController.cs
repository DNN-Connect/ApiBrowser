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

        //var schedule = DotNetNuke.Services.Scheduling.SchedulingController.GetSchedule("Connect.ApiBrowser.Core.ApiScheduledTask, CONNECT.APIBROWSER.CORE", "");
        //if (schedule != null)
        //{
        //    DotNetNuke.Services.Scheduling.SchedulingProvider.Instance().RunScheduleItemNow(schedule);
        //}    
    }
}
