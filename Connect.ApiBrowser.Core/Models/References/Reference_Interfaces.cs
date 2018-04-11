
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
   FromRefMemberId = Convert.ToInt32(Null.SetNull(dr["FromRefMemberId"], FromRefMemberId));
   FromRefStartLine = Convert.ToInt32(Null.SetNull(dr["FromRefStartLine"], FromRefStartLine));
   FromRefEndLine = Convert.ToInt32(Null.SetNull(dr["FromRefEndLine"], FromRefEndLine));
   FromRefMemberName = Convert.ToString(Null.SetNull(dr["FromRefMemberName"], FromRefMemberName));
   FromRefFullName = Convert.ToString(Null.SetNull(dr["FromRefFullName"], FromRefFullName));
   FromRefAppearedInVersion = Convert.ToString(Null.SetNull(dr["FromRefAppearedInVersion"], FromRefAppearedInVersion));
   FromRefDeprecatedInVersion = Convert.ToString(Null.SetNull(dr["FromRefDeprecatedInVersion"], FromRefDeprecatedInVersion));
   FromRefDisappearedInVersion = Convert.ToString(Null.SetNull(dr["FromRefDisappearedInVersion"], FromRefDisappearedInVersion));
   FromRefClassId = Convert.ToInt32(Null.SetNull(dr["FromRefClassId"], FromRefClassId));
   FromRefClassName = Convert.ToString(Null.SetNull(dr["FromRefClassName"], FromRefClassName));
   FromRefFullQualifier = Convert.ToString(Null.SetNull(dr["FromRefFullQualifier"], FromRefFullQualifier));
   ToRefMemberName = Convert.ToString(Null.SetNull(dr["ToRefMemberName"], ToRefMemberName));
   ToRefFullName = Convert.ToString(Null.SetNull(dr["ToRefFullName"], ToRefFullName));
   ToRefAppearedInVersion = Convert.ToString(Null.SetNull(dr["ToRefAppearedInVersion"], ToRefAppearedInVersion));
   ToRefDeprecatedInVersion = Convert.ToString(Null.SetNull(dr["ToRefDeprecatedInVersion"], ToRefDeprecatedInVersion));
   ToRefDisappearedInVersion = Convert.ToString(Null.SetNull(dr["ToRefDisappearedInVersion"], ToRefDisappearedInVersion));
  }
  #endregion

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "fromrefmemberid": // Int
     return FromRefMemberId.ToString(strFormat, formatProvider);
    case "fromrefstartline": // Int
     if (FromRefStartLine == null)
     {
         return "";
     };
     return ((int)FromRefStartLine).ToString(strFormat, formatProvider);
    case "fromrefendline": // Int
     if (FromRefEndLine == null)
     {
         return "";
     };
     return ((int)FromRefEndLine).ToString(strFormat, formatProvider);
    case "fromrefmembername": // VarChar
     return PropertyAccess.FormatString(FromRefMemberName, strFormat);
    case "fromreffullname": // VarChar
     return PropertyAccess.FormatString(FromRefFullName, strFormat);
    case "fromrefappearedinversion": // VarChar
     return PropertyAccess.FormatString(FromRefAppearedInVersion, strFormat);
    case "fromrefdeprecatedinversion": // VarChar
     if (FromRefDeprecatedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(FromRefDeprecatedInVersion, strFormat);
    case "fromrefdisappearedinversion": // VarChar
     if (FromRefDisappearedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(FromRefDisappearedInVersion, strFormat);
    case "fromrefclassid": // Int
     return FromRefClassId.ToString(strFormat, formatProvider);
    case "fromrefclassname": // NVarChar
     return PropertyAccess.FormatString(FromRefClassName, strFormat);
    case "fromreffullqualifier": // NVarChar
     return PropertyAccess.FormatString(FromRefFullQualifier, strFormat);
    case "torefmembername": // VarChar
     if (ToRefMemberName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(ToRefMemberName, strFormat);
    case "toreffullname": // VarChar
     if (ToRefFullName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(ToRefFullName, strFormat);
    case "torefappearedinversion": // VarChar
     if (ToRefAppearedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(ToRefAppearedInVersion, strFormat);
    case "torefdeprecatedinversion": // VarChar
     if (ToRefDeprecatedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(ToRefDeprecatedInVersion, strFormat);
    case "torefdisappearedinversion": // VarChar
     if (ToRefDisappearedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(ToRefDisappearedInVersion, strFormat);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

