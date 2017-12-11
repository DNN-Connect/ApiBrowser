using DotNetNuke.Services.Localization;
using System;

namespace Connect.DNN.Modules.ApiBrowser.Common
{
    public static class Globals
    {
        public const string SharedResourceFileName = "~/DesktopModules/MVC/Connect/ApiBrowser/App_LocalResources/SharedResources.resx";

        public static string ToMemberTypeString(this int value)
        {
            var v = (Connect.ApiBrowser.Core.Models.Members.MemberType)value;
            return Localization.GetString(v.ToString() + "Plural.Text", SharedResourceFileName);
        }
    }

}
