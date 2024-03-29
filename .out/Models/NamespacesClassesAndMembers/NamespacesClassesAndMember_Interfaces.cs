using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.NamespacesClassesAndMembers
{

 [Serializable(), XmlRoot("NamespacesClassesAndMember")]
 public partial class NamespacesClassesAndMember
 {

  #region IPropertyAccess
  public  string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "moduleid": // Int
     return ModuleId.ToString(strFormat, formatProvider);
    case "namespaceid": // Int
     return NamespaceId.ToString(strFormat, formatProvider);
    case "classid": // Int
     return ClassId.ToString(strFormat, formatProvider);
    case "memberid": // Int
     return MemberId.ToString(strFormat, formatProvider);
    case "maintype": // Int
     return MainType.ToString(strFormat, formatProvider);
    case "subtype": // Int
     return SubType.ToString(strFormat, formatProvider);
    case "name": // NVarChar
     return PropertyAccess.FormatString(Name, strFormat);
    case "description": // NVarCharMax
     if (Description == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Description, strFormat);
    case "pendingdescription": // NVarCharMax
     if (PendingDescription == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(PendingDescription, strFormat);
    case "isdeprecated": // Int
     return IsDeprecated.ToString(strFormat, formatProvider);
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
    case "lastmodifiedbyuserid": // Int
     if (LastModifiedByUserID == null)
     {
         return "";
     };
     return ((int)LastModifiedByUserID).ToString(strFormat, formatProvider);
    case "lastmodifiedondate": // DateTime
     if (LastModifiedOnDate == null)
     {
         return "";
     };
     return ((DateTime)LastModifiedOnDate).ToString(strFormat, formatProvider);
    default:
       propertyNotFound = true;
       return "";
       break;
   }
  }
  #endregion

 }
}

