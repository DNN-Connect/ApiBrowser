using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.ApiBrowser.Core.Repositories;
using Connect.DNN.Modules.ApiBrowser.Common;
using System.Web;
using System.IO;
using System.IO.Compression;

namespace Connect.DNN.Modules.ApiBrowser.Api
{

	public partial class FilesController : ApiBrowserApiController
	{

		[HttpPost]
		[DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Upload()
        {
            var context = HttpContext.Current;
            string uplDir = string.Format("{0}Api\\{1}\\", PortalSettings.HomeDirectoryMapPath, ApiBrowserModuleContext.ModuleContext.ModuleID);
            if (!Directory.Exists(uplDir)) Directory.CreateDirectory(uplDir);
            for (int i = 0; i <= context.Request.Files.Count - 1; i++)
            {
                var file = context.Request.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".zip")
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
                    else if (Path.GetExtension(file.FileName).ToLower() == ".xml")
                    {
                        var saveFile = uplDir + file.FileName;
                        file.SaveAs(saveFile);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, Connect.ApiBrowser.Core.Common.Globals.GetScheduledFiles(uplDir));
        }

        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
        public HttpResponseMessage Files()
        {
            string uplDir = string.Format("{0}Api\\{1}\\", PortalSettings.HomeDirectoryMapPath, ApiBrowserModuleContext.ModuleContext.ModuleID);
            return Request.CreateResponse(HttpStatusCode.OK, Connect.ApiBrowser.Core.Common.Globals.GetScheduledFiles(uplDir));
        }
    }
}

