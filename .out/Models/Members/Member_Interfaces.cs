using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Members
{

 [Serializable(), XmlRoot("Member")]
 public partial class Member
 {

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "createdbyuserdisplayname": // NVarChar
     if (CreatedByUserDisplayName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(CreatedByUserDisplayName, strFormat);
    case "lastmodifiedbyuserdisplayname": // NVarChar
     if (LastModifiedByUserDisplayName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(LastModifiedByUserDisplayName, strFormat);
    case "documentationcontents": // NVarCharMax
     if (DocumentationContents == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DocumentationContents, strFormat);
    case "classname": // NVarChar
     return PropertyAccess.FormatString(ClassName, strFormat);
    case "namespacename": // NVarChar
     return PropertyAccess.FormatString(NamespaceName, strFormat);
    case "fullqualifier": // NVarChar
     return PropertyAccess.FormatString(FullQualifier, strFormat);
    case "moduleid": // Int
     return ModuleId.ToString(strFormat, formatProvider);
    case "componentname": // NVarChar
     return PropertyAccess.FormatString(ComponentName, strFormat);
    case "latestversion": // VarChar
     return PropertyAccess.FormatString(LatestVersion, strFormat);
    case "codeblockcount": // Int
     if (CodeBlockCount == null)
     {
         return "";
     };
     return ((int)CodeBlockCount).ToString(strFormat, formatProvider);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

