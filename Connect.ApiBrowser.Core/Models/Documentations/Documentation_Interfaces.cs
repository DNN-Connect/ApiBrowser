
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

  #region IHydratable
  public override void Fill(IDataReader dr)
  {
   base.Fill(dr);
   FullQualifier = Convert.ToString(Null.SetNull(dr["FullQualifier"], FullQualifier));
   IsCurrentVersion = Convert.ToBoolean(Null.SetNull(dr["IsCurrentVersion"], IsCurrentVersion));
   CreatedByUserDisplayName = Convert.ToString(Null.SetNull(dr["CreatedByUserDisplayName"], CreatedByUserDisplayName));
   CreatedByUserEmail = Convert.ToString(Null.SetNull(dr["CreatedByUserEmail"], CreatedByUserEmail));
   LastModifiedByUserDisplayName = Convert.ToString(Null.SetNull(dr["LastModifiedByUserDisplayName"], LastModifiedByUserDisplayName));
   LastModifiedByUserEmail = Convert.ToString(Null.SetNull(dr["LastModifiedByUserEmail"], LastModifiedByUserEmail));
  }
  #endregion

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "fullqualifier": // NVarChar
     if (FullQualifier == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(FullQualifier, strFormat);
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

