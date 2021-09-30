
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Comments
{
    public partial class Comment : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
            FillAuditFields(dr);
   CommentID = Convert.ToInt32(Null.SetNull(dr["CommentID"], CommentID));
   ComponentId = Convert.ToInt32(Null.SetNull(dr["ComponentId"], ComponentId));
   ItemType = Convert.ToInt32(Null.SetNull(dr["ItemType"], ItemType));
   ItemId = Convert.ToInt32(Null.SetNull(dr["ItemId"], ItemId));
   ParentId = Convert.ToInt32(Null.SetNull(dr["ParentId"], ParentId));
   Message = Convert.ToString(Null.SetNull(dr["Message"], Message));
   Approved = Convert.ToBoolean(Null.SetNull(dr["Approved"], Approved));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return CommentID; }
            set { CommentID = value; }
        }
        #endregion

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

