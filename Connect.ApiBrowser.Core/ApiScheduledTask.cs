using System;
using System.Text;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Portals;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core
{
    public class ApiScheduledTask : DotNetNuke.Services.Scheduling.SchedulerClient
    {
        private StringBuilder Log = new StringBuilder();
        public ApiScheduledTask(DotNetNuke.Services.Scheduling.ScheduleHistoryItem objScheduleHistoryItem) : base()
        {
            this.ScheduleHistoryItem = objScheduleHistoryItem;
        }

        public override void DoWork()
        {
            try
            {
                this.Progressing();
                foreach (PortalInfo p in PortalController.Instance.GetPortals())
                {
                    System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(p.HomeDirectoryMapPath + "\\Api");
                    if (d.Exists)
                    {
                        foreach (System.IO.DirectoryInfo sd in d.GetDirectories())
                        {
                            int moduleId = -1;
                            int.TryParse(sd.Name, out moduleId);
                            if (moduleId > -1)
                            {
                                Log.AppendFormat("Found Module Dir {0}" + Environment.NewLine, moduleId);
                                foreach (System.IO.FileInfo f in sd.GetFiles("*.xml"))
                                {
                                    Log.AppendFormat("Analyzing {0}" + Environment.NewLine, f.Name);
                                    XmlApiDocumentation doc = new XmlApiDocumentation(f.FullName, moduleId);
                                    if (doc.IsValid)
                                    {
                                        doc.AddToModule();
                                        Log.AppendFormat("Processed {0}" + Environment.NewLine, f.Name);
                                    }
                                }
                            }
                        }
                    }
                }

                this.ScheduleHistoryItem.AddLogNote(Log.ToString().Replace(Environment.NewLine, "<br />"));
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.AddLogNote(Log.ToString() + Environment.NewLine + "Scheduled task failed: " + ex.Message + "(" + ex.StackTrace + ")" + Environment.NewLine + Log.ToString());
                this.ScheduleHistoryItem.Succeeded = false;
                this.Errored(ref ex);
                Exceptions.LogException(ex);
            }
        }
    }
}
