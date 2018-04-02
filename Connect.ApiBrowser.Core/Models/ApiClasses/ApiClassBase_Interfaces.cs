
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
            FillAuditFields(dr);
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
   DocumentationId = Convert.ToInt32(Null.SetNull(dr["DocumentationId"], DocumentationId));
   PendingDescription = Convert.ToString(Null.SetNull(dr["PendingDescription"], PendingDescription));
   FullName = Convert.ToString(Null.SetNull(dr["FullName"], FullName));
   IsAbstract = Convert.ToBoolean(Null.SetNull(dr["IsAbstract"], IsAbstract));
   IsAnsiClass = Convert.ToBoolean(Null.SetNull(dr["IsAnsiClass"], IsAnsiClass));
   IsArray = Convert.ToBoolean(Null.SetNull(dr["IsArray"], IsArray));
   IsAutoClass = Convert.ToBoolean(Null.SetNull(dr["IsAutoClass"], IsAutoClass));
   IsAutoLayout = Convert.ToBoolean(Null.SetNull(dr["IsAutoLayout"], IsAutoLayout));
   IsBeforeFieldInit = Convert.ToBoolean(Null.SetNull(dr["IsBeforeFieldInit"], IsBeforeFieldInit));
   IsByReference = Convert.ToBoolean(Null.SetNull(dr["IsByReference"], IsByReference));
   IsClass = Convert.ToBoolean(Null.SetNull(dr["IsClass"], IsClass));
   IsDefinition = Convert.ToBoolean(Null.SetNull(dr["IsDefinition"], IsDefinition));
   IsEnum = Convert.ToBoolean(Null.SetNull(dr["IsEnum"], IsEnum));
   IsExplicitLayout = Convert.ToBoolean(Null.SetNull(dr["IsExplicitLayout"], IsExplicitLayout));
   IsFunctionPointer = Convert.ToBoolean(Null.SetNull(dr["IsFunctionPointer"], IsFunctionPointer));
   IsGenericInstance = Convert.ToBoolean(Null.SetNull(dr["IsGenericInstance"], IsGenericInstance));
   IsGenericParameter = Convert.ToBoolean(Null.SetNull(dr["IsGenericParameter"], IsGenericParameter));
   IsImport = Convert.ToBoolean(Null.SetNull(dr["IsImport"], IsImport));
   IsInterface = Convert.ToBoolean(Null.SetNull(dr["IsInterface"], IsInterface));
   IsNested = Convert.ToBoolean(Null.SetNull(dr["IsNested"], IsNested));
   IsNestedAssembly = Convert.ToBoolean(Null.SetNull(dr["IsNestedAssembly"], IsNestedAssembly));
   IsNestedPrivate = Convert.ToBoolean(Null.SetNull(dr["IsNestedPrivate"], IsNestedPrivate));
   IsNestedPublic = Convert.ToBoolean(Null.SetNull(dr["IsNestedPublic"], IsNestedPublic));
   IsNotPublic = Convert.ToBoolean(Null.SetNull(dr["IsNotPublic"], IsNotPublic));
   ParentClassId = Convert.ToInt32(Null.SetNull(dr["ParentClassId"], ParentClassId));
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

