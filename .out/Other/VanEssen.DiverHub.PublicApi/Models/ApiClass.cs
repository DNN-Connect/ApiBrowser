using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_ApiClasses")]
    [PrimaryKey("ClassId", AutoIncrement = true)]
    public partial class ApiClass
    {

        public int ClassId { get; set; }
        public int NamespaceId { get; set; }
        public int? ComponentId { get; set; }
        public string ClassName { get; set; }
        public string Declaration { get; set; }
        public string Documentation { get; set; }
        public string Description { get; set; }
        public string AppearedInVersion { get; set; }
        public string DeprecatedInVersion { get; set; }
        public string DisappearedInVersion { get; set; }
        public bool IsDeprecated { get; set; }
        public string DeprecationMessage { get; set; }
        public int? DocumentationId { get; set; }
        public string PendingDescription { get; set; }
        public string FullName { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsAnsiClass { get; set; }
        public bool IsArray { get; set; }
        public bool IsAutoClass { get; set; }
        public bool IsAutoLayout { get; set; }
        public bool IsBeforeFieldInit { get; set; }
        public bool IsByReference { get; set; }
        public bool IsClass { get; set; }
        public bool IsDefinition { get; set; }
        public bool IsEnum { get; set; }
        public bool IsExplicitLayout { get; set; }
        public bool IsFunctionPointer { get; set; }
        public bool IsGenericInstance { get; set; }
        public bool IsGenericParameter { get; set; }
        public bool IsImport { get; set; }
        public bool IsInterface { get; set; }
        public bool IsNested { get; set; }
        public bool IsNestedAssembly { get; set; }
        public bool IsNestedPrivate { get; set; }
        public bool IsNestedPublic { get; set; }
        public bool IsNotPublic { get; set; }
        public int ParentClassId { get; set; }
        public string CreatedByUserDisplayName { get; set; }
        public string LastModifiedByUserDisplayName { get; set; }
        public string DocumentationContents { get; set; }
        public string NamespaceName { get; set; }
        public string FullQualifier { get; set; }
        public int ModuleId { get; set; }
        public string ComponentName { get; set; }
        public string LatestVersion { get; set; }
        public int? MemberCount { get; set; }
    }
}
