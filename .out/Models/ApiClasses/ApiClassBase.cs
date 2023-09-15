using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{
    [TableName("Connect_ApiBrowser_ApiClasses")]
    [PrimaryKey("ClassId", AutoIncrement = true)]
    [DataContract]
    public partial class ApiClassBase  : AuditableEntity 
    {

        #region .ctor
        public ApiClassBase()
        {
            ClassId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public int NamespaceId { get; set; }
        [DataMember]
        public int? ComponentId { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Declaration { get; set; }
        [DataMember]
        public string Documentation { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string AppearedInVersion { get; set; }
        [DataMember]
        public string DeprecatedInVersion { get; set; }
        [DataMember]
        public string DisappearedInVersion { get; set; }
        [DataMember]
        public bool IsDeprecated { get; set; }
        [DataMember]
        public string DeprecationMessage { get; set; }
        [DataMember]
        public int? DocumentationId { get; set; }
        [DataMember]
        public string PendingDescription { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public bool IsAbstract { get; set; }
        [DataMember]
        public bool IsAnsiClass { get; set; }
        [DataMember]
        public bool IsArray { get; set; }
        [DataMember]
        public bool IsAutoClass { get; set; }
        [DataMember]
        public bool IsAutoLayout { get; set; }
        [DataMember]
        public bool IsBeforeFieldInit { get; set; }
        [DataMember]
        public bool IsByReference { get; set; }
        [DataMember]
        public bool IsClass { get; set; }
        [DataMember]
        public bool IsDefinition { get; set; }
        [DataMember]
        public bool IsEnum { get; set; }
        [DataMember]
        public bool IsExplicitLayout { get; set; }
        [DataMember]
        public bool IsFunctionPointer { get; set; }
        [DataMember]
        public bool IsGenericInstance { get; set; }
        [DataMember]
        public bool IsGenericParameter { get; set; }
        [DataMember]
        public bool IsImport { get; set; }
        [DataMember]
        public bool IsInterface { get; set; }
        [DataMember]
        public bool IsNested { get; set; }
        [DataMember]
        public bool IsNestedAssembly { get; set; }
        [DataMember]
        public bool IsNestedPrivate { get; set; }
        [DataMember]
        public bool IsNestedPublic { get; set; }
        [DataMember]
        public bool IsNotPublic { get; set; }
        [DataMember]
        public int ParentClassId { get; set; }
        #endregion

        #region Methods
        public void ReadApiClassBase(ApiClassBase apiClass)
        {
            ClassId = apiClass.ClassId;
            NamespaceId = apiClass.NamespaceId;
            ComponentId = apiClass.ComponentId;
            ClassName = apiClass.ClassName;
            Declaration = apiClass.Declaration;
            Documentation = apiClass.Documentation;
            Description = apiClass.Description;
            AppearedInVersion = apiClass.AppearedInVersion;
            DeprecatedInVersion = apiClass.DeprecatedInVersion;
            DisappearedInVersion = apiClass.DisappearedInVersion;
            IsDeprecated = apiClass.IsDeprecated;
            DeprecationMessage = apiClass.DeprecationMessage;
            DocumentationId = apiClass.DocumentationId;
            PendingDescription = apiClass.PendingDescription;
            FullName = apiClass.FullName;
            IsAbstract = apiClass.IsAbstract;
            IsAnsiClass = apiClass.IsAnsiClass;
            IsArray = apiClass.IsArray;
            IsAutoClass = apiClass.IsAutoClass;
            IsAutoLayout = apiClass.IsAutoLayout;
            IsBeforeFieldInit = apiClass.IsBeforeFieldInit;
            IsByReference = apiClass.IsByReference;
            IsClass = apiClass.IsClass;
            IsDefinition = apiClass.IsDefinition;
            IsEnum = apiClass.IsEnum;
            IsExplicitLayout = apiClass.IsExplicitLayout;
            IsFunctionPointer = apiClass.IsFunctionPointer;
            IsGenericInstance = apiClass.IsGenericInstance;
            IsGenericParameter = apiClass.IsGenericParameter;
            IsImport = apiClass.IsImport;
            IsInterface = apiClass.IsInterface;
            IsNested = apiClass.IsNested;
            IsNestedAssembly = apiClass.IsNestedAssembly;
            IsNestedPrivate = apiClass.IsNestedPrivate;
            IsNestedPublic = apiClass.IsNestedPublic;
            IsNotPublic = apiClass.IsNotPublic;
            ParentClassId = apiClass.ParentClassId;
        }
        #endregion

    }
}



