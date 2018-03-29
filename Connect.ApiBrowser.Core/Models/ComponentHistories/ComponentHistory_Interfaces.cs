
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.ComponentHistories
{
    public partial class ComponentHistory : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
   ComponentHistoryId = Convert.ToInt32(Null.SetNull(dr["ComponentHistoryId"], ComponentHistoryId));
   ComponentId = Convert.ToInt32(Null.SetNull(dr["ComponentId"], ComponentId));
   Version = Convert.ToString(Null.SetNull(dr["Version"], Version));
   VersionNormalized = Convert.ToString(Null.SetNull(dr["VersionNormalized"], VersionNormalized));
   FullName = Convert.ToString(Null.SetNull(dr["FullName"], FullName));
   CodeLines = Convert.ToInt32(Null.SetNull(dr["CodeLines"], CodeLines));
   CommentLines = Convert.ToInt32(Null.SetNull(dr["CommentLines"], CommentLines));
   EmptyLines = Convert.ToInt32(Null.SetNull(dr["EmptyLines"], EmptyLines));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return ComponentHistoryId; }
            set { ComponentHistoryId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "componenthistoryid": // Int
     return ComponentHistoryId.ToString(strFormat, formatProvider);
    case "componentid": // Int
     return ComponentId.ToString(strFormat, formatProvider);
    case "version": // VarChar
     return PropertyAccess.FormatString(Version, strFormat);
    case "versionnormalized": // VarChar
     return PropertyAccess.FormatString(VersionNormalized, strFormat);
    case "fullname": // VarChar
     return PropertyAccess.FormatString(FullName, strFormat);
    case "codelines": // Int
     return CodeLines.ToString(strFormat, formatProvider);
    case "commentlines": // Int
     if (CommentLines == null)
     {
         return "";
     };
     return ((int)CommentLines).ToString(strFormat, formatProvider);
    case "emptylines": // Int
     if (EmptyLines == null)
     {
         return "";
     };
     return ((int)EmptyLines).ToString(strFormat, formatProvider);
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

