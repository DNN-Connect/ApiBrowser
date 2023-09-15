using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Members
{
    public partial class MemberBase : IPropertyAccess
    {
        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "memberid": // Int
     return MemberId.ToString(strFormat, formatProvider);
    case "classid": // Int
     return ClassId.ToString(strFormat, formatProvider);
    case "membertype": // Int
     return MemberType.ToString(strFormat, formatProvider);
    case "membername": // VarChar
     return PropertyAccess.FormatString(MemberName, strFormat);
    case "declaration": // VarChar
     if (Declaration == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Declaration, strFormat);
    case "documentation": // NVarCharMax
     if (Documentation == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Documentation, strFormat);
    case "description": // NVarCharMax
     if (Description == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Description, strFormat);
    case "appearedinversion": // VarChar
     return PropertyAccess.FormatString(AppearedInVersion, strFormat);
    case "deprecatedinversion": // VarChar
     if (DeprecatedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DeprecatedInVersion, strFormat);
    case "disappearedinversion": // VarChar
     if (DisappearedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DisappearedInVersion, strFormat);
    case "isdeprecated": // Bit
     return IsDeprecated.ToString();
    case "deprecationmessage": // NVarChar
     if (DeprecationMessage == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DeprecationMessage, strFormat);
    case "documentationid": // Int
     if (DocumentationId == null)
     {
         return "";
     };
     return ((int)DocumentationId).ToString(strFormat, formatProvider);
    case "pendingdescription": // NVarCharMax
     if (PendingDescription == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(PendingDescription, strFormat);
    case "fullname": // VarChar
     return PropertyAccess.FormatString(FullName, strFormat);
    case "isabstract": // Bit
     return IsAbstract.ToString();
    case "isprivate": // Bit
     return IsPrivate.ToString();
    case "isstatic": // Bit
     return IsStatic.ToString();
    case "isgetter": // Bit
     return IsGetter.ToString();
    case "issetter": // Bit
     return IsSetter.ToString();
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

