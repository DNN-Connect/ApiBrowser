
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

  #region IHydratable
  public override void Fill(IDataReader dr)
  {
   base.Fill(dr);
   ClassName = Convert.ToString(Null.SetNull(dr["ClassName"], ClassName));
   NamespaceName = Convert.ToString(Null.SetNull(dr["NamespaceName"], NamespaceName));
   ComponentName = Convert.ToString(Null.SetNull(dr["ComponentName"], ComponentName));
   LatestVersion = Convert.ToString(Null.SetNull(dr["LatestVersion"], LatestVersion));
   CodeBlockCount = Convert.ToInt32(Null.SetNull(dr["CodeBlockCount"], CodeBlockCount));
  }
  #endregion

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "classname": // NVarChar
     return PropertyAccess.FormatString(ClassName, strFormat);
    case "namespacename": // NVarChar
     return PropertyAccess.FormatString(NamespaceName, strFormat);
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

