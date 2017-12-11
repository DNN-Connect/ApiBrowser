using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using System.IO;
using System.IO.Compression;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class FilesController : ApiBrowserMvcController
    {
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        public class UploadDTO
        {
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(UploadDTO data)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    string uplDir = string.Format("{0}\\Api\\{1}\\", PortalSettings.HomeDirectoryMapPath, ModuleContext.ModuleId);
                    if (!Directory.Exists(uplDir)) Directory.CreateDirectory(uplDir);
                    if (Path.GetExtension(file.FileName) == ".zip")
                    {
                        using (var archive = new ZipArchive(file.InputStream))
                        {
                            foreach (var entry in archive.Entries)
                            {
                                if (entry.Name.EndsWith(".xml", System.StringComparison.OrdinalIgnoreCase))
                                {
                                    var saveFile = uplDir + entry.Name;
                                    entry.ExtractToFile(saveFile);
                                }
                            }
                        }
                    }
                    else if (Path.GetExtension(file.FileName) == ".xml")
                    {
                        var saveFile = uplDir + file.FileName;
                        file.SaveAs(saveFile);
                    }
                }
                var schedule = DotNetNuke.Services.Scheduling.SchedulingController.GetSchedule("Connect.ApiBrowser.Core.ApiScheduledTask, CONNECT.APIBROWSER.CORE", "");
                if (schedule != null)
                {
                    DotNetNuke.Services.Scheduling.SchedulingProvider.Instance().RunScheduleItemNow(schedule);
                }
            }
            return View();
        }
    }
}
