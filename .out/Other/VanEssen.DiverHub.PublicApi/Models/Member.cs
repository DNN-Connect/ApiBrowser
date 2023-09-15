using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_Members")]
    [PrimaryKey("MemberId", AutoIncrement = true)]
    public partial class Member
    {

        public int MemberId { get; set; }
        public int ClassId { get; set; }
        public int MemberType { get; set; }
        public string MemberName { get; set; }
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
        public bool IsPrivate { get; set; }
        public bool IsStatic { get; set; }
        public bool IsGetter { get; set; }
        public bool IsSetter { get; set; }
        public string CreatedByUserDisplayName { get; set; }
        public string LastModifiedByUserDisplayName { get; set; }
        public string DocumentationContents { get; set; }
        public string ClassName { get; set; }
        public string NamespaceName { get; set; }
        public string FullQualifier { get; set; }
        public int ModuleId { get; set; }
        public string ComponentName { get; set; }
        public string LatestVersion { get; set; }
        public int? CodeBlockCount { get; set; }
    }
}
