
using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Dependencies
{

 [Serializable(), XmlRoot("Dependency")]
 public partial class Dependency
 {

  #region IHydratable
  public override void Fill(IDataReader dr)
  {
   base.Fill(dr);
   ComponentName = Convert.ToString(Null.SetNull(dr["ComponentName"], ComponentName));
   LatestVersion = Convert.ToString(Null.SetNull(dr["LatestVersion"], LatestVersion));
   DependentComponentName = Convert.ToString(Null.SetNull(dr["DependentComponentName"], DependentComponentName));
  }
  #endregion

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "componentname": // NVarChar
     return PropertyAccess.FormatString(ComponentName, strFormat);
    case "latestversion": // VarChar
     return PropertyAccess.FormatString(LatestVersion, strFormat);
    case "dependentcomponentname": // NVarChar
     if (DependentComponentName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DependentComponentName, strFormat);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

