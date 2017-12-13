
using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.NamespacesAndClasses
{

 [Serializable(), XmlRoot("NamespacesAndClass")]
 public partial class NamespacesAndClass
 {

  #region IHydratable
  public  void Fill(IDataReader dr)
  {
   ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleId"], ModuleId));
   NamespaceId = Convert.ToInt32(Null.SetNull(dr["NamespaceId"], NamespaceId));
   ClassId = Convert.ToInt32(Null.SetNull(dr["ClassId"], ClassId));
   IsClass = Convert.ToBoolean(Null.SetNull(dr["IsClass"], IsClass));
   Name = Convert.ToString(Null.SetNull(dr["Name"], Name));
   Description = Convert.ToString(Null.SetNull(dr["Description"], Description));
   IsDeprecated = Convert.ToInt32(Null.SetNull(dr["IsDeprecated"], IsDeprecated));
   DeprecatedInVersion = Convert.ToString(Null.SetNull(dr["DeprecatedInVersion"], DeprecatedInVersion));
   DisappearedInVersion = Convert.ToString(Null.SetNull(dr["DisappearedInVersion"], DisappearedInVersion));
  }
  #endregion

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
    case "isclass": // Bit
     if (IsClass == null)
     {
         return "";
     };
     return IsClass.ToString();
    case "name": // NVarChar
     return PropertyAccess.FormatString(Name, strFormat);
    case "description": // NVarCharMax
     if (Description == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Description, strFormat);
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
    default:
       propertyNotFound = true;
       return "";
       break;
   }
  }
  #endregion

 }
}

