
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{
    public partial class ApiClassBase : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
   ClassId = Convert.ToInt32(Null.SetNull(dr["ClassId"], ClassId));
   NamespaceId = Convert.ToInt32(Null.SetNull(dr["NamespaceId"], NamespaceId));
   ComponentId = Convert.ToInt32(Null.SetNull(dr["ComponentId"], ComponentId));
   ClassName = Convert.ToString(Null.SetNull(dr["ClassName"], ClassName));
   Declaration = Convert.ToString(Null.SetNull(dr["Declaration"], Declaration));
   Documentation = Convert.ToString(Null.SetNull(dr["Documentation"], Documentation));
   Description = Convert.ToString(Null.SetNull(dr["Description"], Description));
   AppearedInVersion = Convert.ToString(Null.SetNull(dr["AppearedInVersion"], AppearedInVersion));
   DeprecatedInVersion = Convert.ToString(Null.SetNull(dr["DeprecatedInVersion"], DeprecatedInVersion));
   DisappearedInVersion = Convert.ToString(Null.SetNull(dr["DisappearedInVersion"], DisappearedInVersion));
   IsDeprecated = Convert.ToBoolean(Null.SetNull(dr["IsDeprecated"], IsDeprecated));
   DeprecationMessage = Convert.ToString(Null.SetNull(dr["DeprecationMessage"], DeprecationMessage));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return ClassId; }
            set { ClassId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "classid": // Int
     return ClassId.ToString(strFormat, formatProvider);
    case "namespaceid": // Int
     return NamespaceId.ToString(strFormat, formatProvider);
    case "componentid": // Int
     if (ComponentId == null)
     {
         return "";
     };
     return ((int)ComponentId).ToString(strFormat, formatProvider);
    case "classname": // NVarChar
     return PropertyAccess.FormatString(ClassName, strFormat);
    case "declaration": // NVarChar
     if (Declaration == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Declaration, strFormat);
    case "documentation": // NVarCharMax
     if (Documentation == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Documentation, strFormat);
    case "description": // NVarCharMax
     if (Description == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Description, strFormat);
    case "appearedinversion": // VarChar
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
    case "isdeprecated": // Bit
     return IsDeprecated.ToString();
    case "deprecationmessage": // NVarChar
     if (DeprecationMessage == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DeprecationMessage, strFormat);
                default:
                    propertyNotFound = true;
                    break;
            }

            return Null.NullString;
        }

        [IgnoreColumn()]
        public CacheLevel Cacheability
        {
            get { return CacheLevel.fullyCacheable; }
        }
        #endregion

    }
}

