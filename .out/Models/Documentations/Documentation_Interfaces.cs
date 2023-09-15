using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Documentations
{

 [Serializable(), XmlRoot("Documentation")]
 public partial class Documentation
 {

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "iscurrentversion": // Bit
     if (IsCurrentVersion == null)
     {
         return "";
     };
     return IsCurrentVersion.ToString();
    case "createdbyuserdisplayname": // NVarChar
     return PropertyAccess.FormatString(CreatedByUserDisplayName, strFormat);
    case "createdbyuseremail": // NVarChar
     if (CreatedByUserEmail == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(CreatedByUserEmail, strFormat);
    case "lastmodifiedbyuserdisplayname": // NVarChar
     return PropertyAccess.FormatString(LastModifiedByUserDisplayName, strFormat);
    case "lastmodifiedbyuseremail": // NVarChar
     if (LastModifiedByUserEmail == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(LastModifiedByUserEmail, strFormat);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

