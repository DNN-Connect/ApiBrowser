using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{

    [TableName("vw_Connect_ApiBrowser_ApiClasses")]
    [PrimaryKey("ClassId", AutoIncrement = true)]
    [DataContract]
    public partial class ApiClass  : ApiClassBase 
    {

        #region .ctor
        public ApiClass()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public string CreatedByUserDisplayName { get; set; }
        [DataMember]
        public string LastModifiedByUserDisplayName { get; set; }
        [DataMember]
        public string DocumentationContents { get; set; }
        [DataMember]
        public string NamespaceName { get; set; }
        [DataMember]
        public string FullQualifier { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public string LatestVersion { get; set; }
        [DataMember]
        public int? MemberCount { get; set; }
        #endregion

        #region Methods
        public ApiClassBase GetApiClassBase()
        {
            ApiClassBase res = new ApiClassBase();
             res.ClassId = ClassId;
             res.NamespaceId = NamespaceId;
             res.ComponentId = ComponentId;
             res.ClassName = ClassName;
             res.Declaration = Declaration;
             res.Documentation = Documentation;
             res.Description = Description;
             res.AppearedInVersion = AppearedInVersion;
             res.DeprecatedInVersion = DeprecatedInVersion;
             res.DisappearedInVersion = DisappearedInVersion;
             res.IsDeprecated = IsDeprecated;
             res.DeprecationMessage = DeprecationMessage;
             res.DocumentationId = DocumentationId;
             res.PendingDescription = PendingDescription;
             res.FullName = FullName;
             res.IsAbstract = IsAbstract;
             res.IsAnsiClass = IsAnsiClass;
             res.IsArray = IsArray;
             res.IsAutoClass = IsAutoClass;
             res.IsAutoLayout = IsAutoLayout;
             res.IsBeforeFieldInit = IsBeforeFieldInit;
             res.IsByReference = IsByReference;
             res.IsClass = IsClass;
             res.IsDefinition = IsDefinition;
             res.IsEnum = IsEnum;
             res.IsExplicitLayout = IsExplicitLayout;
             res.IsFunctionPointer = IsFunctionPointer;
             res.IsGenericInstance = IsGenericInstance;
             res.IsGenericParameter = IsGenericParameter;
             res.IsImport = IsImport;
             res.IsInterface = IsInterface;
             res.IsNested = IsNested;
             res.IsNestedAssembly = IsNestedAssembly;
             res.IsNestedPrivate = IsNestedPrivate;
             res.IsNestedPublic = IsNestedPublic;
             res.IsNotPublic = IsNotPublic;
             res.ParentClassId = ParentClassId;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        public ApiClass Clone()
        {
            ApiClass res = new ApiClass();
            res.ClassId = ClassId;
            res.NamespaceId = NamespaceId;
            res.ComponentId = ComponentId;
            res.ClassName = ClassName;
            res.Declaration = Declaration;
            res.Documentation = Documentation;
            res.Description = Description;
            res.AppearedInVersion = AppearedInVersion;
            res.DeprecatedInVersion = DeprecatedInVersion;
            res.DisappearedInVersion = DisappearedInVersion;
            res.IsDeprecated = IsDeprecated;
            res.DeprecationMessage = DeprecationMessage;
            res.DocumentationId = DocumentationId;
            res.PendingDescription = PendingDescription;
            res.FullName = FullName;
            res.IsAbstract = IsAbstract;
            res.IsAnsiClass = IsAnsiClass;
            res.IsArray = IsArray;
            res.IsAutoClass = IsAutoClass;
            res.IsAutoLayout = IsAutoLayout;
            res.IsBeforeFieldInit = IsBeforeFieldInit;
            res.IsByReference = IsByReference;
            res.IsClass = IsClass;
            res.IsDefinition = IsDefinition;
            res.IsEnum = IsEnum;
            res.IsExplicitLayout = IsExplicitLayout;
            res.IsFunctionPointer = IsFunctionPointer;
            res.IsGenericInstance = IsGenericInstance;
            res.IsGenericParameter = IsGenericParameter;
            res.IsImport = IsImport;
            res.IsInterface = IsInterface;
            res.IsNested = IsNested;
            res.IsNestedAssembly = IsNestedAssembly;
            res.IsNestedPrivate = IsNestedPrivate;
            res.IsNestedPublic = IsNestedPublic;
            res.IsNotPublic = IsNotPublic;
            res.ParentClassId = ParentClassId;
            res.CreatedByUserDisplayName = CreatedByUserDisplayName;
            res.LastModifiedByUserDisplayName = LastModifiedByUserDisplayName;
            res.DocumentationContents = DocumentationContents;
            res.NamespaceName = NamespaceName;
            res.FullQualifier = FullQualifier;
            res.ModuleId = ModuleId;
            res.ComponentName = ComponentName;
            res.LatestVersion = LatestVersion;
            res.MemberCount = MemberCount;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        #endregion

    }
}
