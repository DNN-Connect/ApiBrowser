
using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.References
{

 [Serializable(), XmlRoot("Reference")]
 public partial class Reference
 {

  #region IHydratable
  public override void Fill(IDataReader dr)
  {
   base.Fill(dr);
   MemberName = Convert.ToString(Null.SetNull(dr["MemberName"], MemberName));
   AppearedInVersion = Convert.ToString(Null.SetNull(dr["AppearedInVersion"], AppearedInVersion));
   DeprecatedInVersion = Convert.ToString(Null.SetNull(dr["DeprecatedInVersion"], DeprecatedInVersion));
   DisappearedInVersion = Convert.ToString(Null.SetNull(dr["DisappearedInVersion"], DisappearedInVersion));
  }
  #endregion

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "membername": // VarChar
     if (MemberName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(MemberName, strFormat);
    case "appearedinversion": // VarChar
     if (AppearedInVersion == null)
     {
         return "";
     };
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
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

