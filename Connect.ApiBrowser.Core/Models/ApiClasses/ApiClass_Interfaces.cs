
using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{

 [Serializable(), XmlRoot("ApiClass")]
 public partial class ApiClass
 {

  #region IHydratable
  public override void Fill(IDataReader dr)
  {
   base.Fill(dr);
   CreatedByUserDisplayName = Convert.ToString(Null.SetNull(dr["CreatedByUserDisplayName"], CreatedByUserDisplayName));
   LastModifiedByUserDisplayName = Convert.ToString(Null.SetNull(dr["LastModifiedByUserDisplayName"], LastModifiedByUserDisplayName));
   DocumentationContents = Convert.ToString(Null.SetNull(dr["DocumentationContents"], DocumentationContents));
   NamespaceName = Convert.ToString(Null.SetNull(dr["NamespaceName"], NamespaceName));
   FullQualifier = Convert.ToString(Null.SetNull(dr["FullQualifier"], FullQualifier));
   ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleId"], ModuleId));
   ComponentName = Convert.ToString(Null.SetNull(dr["ComponentName"], ComponentName));
   LatestVersion = Convert.ToString(Null.SetNull(dr["LatestVersion"], LatestVersion));
   MemberCount = Convert.ToInt32(Null.SetNull(dr["MemberCount"], MemberCount));
  }
  #endregion

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
    case "membercount": // Int
     if (MemberCount == null)
     {
         return "";
     };
     return ((int)MemberCount).ToString(strFormat, formatProvider);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

