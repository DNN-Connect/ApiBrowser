
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.Members
{

    [TableName("vw_Connect_ApiBrowser_Members")]
    [PrimaryKey("MemberId", AutoIncrement = true)]
    [DataContract]
    public partial class Member  : MemberBase 
    {

        #region .ctor
        public Member()  : base() 
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
        public string ClassName { get; set; }
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
        public int? CodeBlockCount { get; set; }
        #endregion

        #region Methods
        public MemberBase GetMemberBase()
        {
            MemberBase res = new MemberBase();
             res.MemberId = MemberId;
             res.ClassId = ClassId;
             res.MemberType = MemberType;
             res.MemberName = MemberName;
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
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        public Member Clone()
        {
            Member res = new Member();
            res.MemberId = MemberId;
            res.ClassId = ClassId;
            res.MemberType = MemberType;
            res.MemberName = MemberName;
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
            res.CreatedByUserDisplayName = CreatedByUserDisplayName;
            res.LastModifiedByUserDisplayName = LastModifiedByUserDisplayName;
            res.DocumentationContents = DocumentationContents;
            res.ClassName = ClassName;
            res.NamespaceName = NamespaceName;
            res.FullQualifier = FullQualifier;
            res.ModuleId = ModuleId;
            res.ComponentName = ComponentName;
            res.LatestVersion = LatestVersion;
            res.CodeBlockCount = CodeBlockCount;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        #endregion

    }
}
