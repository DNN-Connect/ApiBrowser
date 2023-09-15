using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Comments
{
    public partial class Comment : IPropertyAccess
    {
        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "commentid": // Int
     return CommentID.ToString(strFormat, formatProvider);
    case "componentid": // Int
     return ComponentId.ToString(strFormat, formatProvider);
    case "itemtype": // Int
     return ItemType.ToString(strFormat, formatProvider);
    case "itemid": // Int
     return ItemId.ToString(strFormat, formatProvider);
    case "parentid": // Int
     if (ParentId == null)
     {
         return "";
     };
     return ((int)ParentId).ToString(strFormat, formatProvider);
    case "message": // NVarCharMax
     return PropertyAccess.FormatString(Message, strFormat);
    case "approved": // Bit
     if (Approved == null)
     {
         return "";
     };
     return Approved.ToString();
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

