using System;

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
    }
}
