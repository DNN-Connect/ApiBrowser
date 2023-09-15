using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.References
{
    public partial class ReferenceBase : IPropertyAccess
    {
        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "referenceid": // Int
     return ReferenceId.ToString(strFormat, formatProvider);
    case "codeblockid": // Int
     return CodeBlockId.ToString(strFormat, formatProvider);
    case "fullname": // VarChar
     return PropertyAccess.FormatString(FullName, strFormat);
    case "offset": // Int
     return Offset.ToString(strFormat, formatProvider);
    case "referencedmemberid": // Int
     if (ReferencedMemberId == null)
     {
         return "";
     };
     return ((int)ReferencedMemberId).ToString(strFormat, formatProvider);
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

