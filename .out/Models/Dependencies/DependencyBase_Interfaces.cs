using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Dependencies
{
    public partial class DependencyBase : IPropertyAccess
    {
        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "dependencyid": // Int
     return DependencyId.ToString(strFormat, formatProvider);
    case "componenthistoryid": // Int
     return ComponentHistoryId.ToString(strFormat, formatProvider);
    case "fullname": // VarChar
     return PropertyAccess.FormatString(FullName, strFormat);
    case "version": // VarChar
     return PropertyAccess.FormatString(Version, strFormat);
    case "versionnormalized": // VarChar
     return PropertyAccess.FormatString(VersionNormalized, strFormat);
    case "name": // VarChar
     return PropertyAccess.FormatString(Name, strFormat);
    case "depcomponenthistoryid": // Int
     if (DepComponentHistoryId == null)
     {
         return "";
     };
     return ((int)DepComponentHistoryId).ToString(strFormat, formatProvider);
                default:
                    propertyNotFound = true;
                    break;
            }

            return Null.NullString;
        }

        [IgnoreColumn()]
        public CacheLevel Cacheability
        {
            get { return CacheLevel.fullyCacheable; }
        }
        #endregion

    }
}

