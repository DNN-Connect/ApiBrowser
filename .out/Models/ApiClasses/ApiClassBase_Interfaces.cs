using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{
    public partial class ApiClassBase : IPropertyAccess
    {
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
    case "documentationid": // Int
     if (DocumentationId == null)
     {
         return "";
     };
     return ((int)DocumentationId).ToString(strFormat, formatProvider);
    case "pendingdescription": // NVarCharMax
     if (PendingDescription == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(PendingDescription, strFormat);
    case "fullname": // VarChar
     return PropertyAccess.FormatString(FullName, strFormat);
    case "isabstract": // Bit
     return IsAbstract.ToString();
    case "isansiclass": // Bit
     return IsAnsiClass.ToString();
    case "isarray": // Bit
     return IsArray.ToString();
    case "isautoclass": // Bit
     return IsAutoClass.ToString();
    case "isautolayout": // Bit
     return IsAutoLayout.ToString();
    case "isbeforefieldinit": // Bit
     return IsBeforeFieldInit.ToString();
    case "isbyreference": // Bit
     return IsByReference.ToString();
    case "isclass": // Bit
     return IsClass.ToString();
    case "isdefinition": // Bit
     return IsDefinition.ToString();
    case "isenum": // Bit
     return IsEnum.ToString();
    case "isexplicitlayout": // Bit
     return IsExplicitLayout.ToString();
    case "isfunctionpointer": // Bit
     return IsFunctionPointer.ToString();
    case "isgenericinstance": // Bit
     return IsGenericInstance.ToString();
    case "isgenericparameter": // Bit
     return IsGenericParameter.ToString();
    case "isimport": // Bit
     return IsImport.ToString();
    case "isinterface": // Bit
     return IsInterface.ToString();
    case "isnested": // Bit
     return IsNested.ToString();
    case "isnestedassembly": // Bit
     return IsNestedAssembly.ToString();
    case "isnestedprivate": // Bit
     return IsNestedPrivate.ToString();
    case "isnestedpublic": // Bit
     return IsNestedPublic.ToString();
    case "isnotpublic": // Bit
     return IsNotPublic.ToString();
    case "parentclassid": // Int
     return ParentClassId.ToString(strFormat, formatProvider);
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

