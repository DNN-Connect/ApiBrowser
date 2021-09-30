using Connect.ApiBrowser.Core.Models;
using System;
using System.Collections.Generic;

namespace Connect.ApiBrowser.Core.Common
{
    public static class Globals
    {
        public static void Log(this System.IO.StreamWriter sw, DateTime startTime, string messageFormat, params object[] pars)
        {
            TimeSpan t = DateTime.Now.Subtract(startTime);
            sw.Write(string.Format("{0:0000.00} ", t.TotalSeconds));
            sw.WriteLine(string.Format(messageFormat, pars));
            sw.Flush();
        }
        public static List<ScheduledFile> GetScheduledFiles(string path)
        {
            var res = new List<ScheduledFile>();
            var d = new System.IO.DirectoryInfo(path);
            if (d.Exists)
            {
                foreach (var f in d.GetFiles("*.xml"))
                {
                    res.Add(new ScheduledFile()
                    {
                        Name = f.Name,
                        Size = f.Length,
                        Processing = System.IO.File.Exists(f.FullName.Replace(".xml", ".log"))
                    });
                }
            }
            return res;
        }
    }
}
