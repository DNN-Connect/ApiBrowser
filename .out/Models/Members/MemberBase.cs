using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Members
{
    [TableName("Connect_ApiBrowser_Members")]
    [PrimaryKey("MemberId", AutoIncrement = true)]
    [DataContract]
    public partial class MemberBase  : AuditableEntity 
    {

        #region .ctor
        public MemberBase()
        {
            MemberId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int MemberId { get; set; }
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public int MemberType { get; set; }
        [DataMember]
        public string MemberName { get; set; }
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
        public bool IsPrivate { get; set; }
        [DataMember]
        public bool IsStatic { get; set; }
        [DataMember]
        public bool IsGetter { get; set; }
        [DataMember]
        public bool IsSetter { get; set; }
        #endregion

        #region Methods
        public void ReadMemberBase(MemberBase member)
        {
            MemberId = member.MemberId;
            ClassId = member.ClassId;
            MemberType = member.MemberType;
            MemberName = member.MemberName;
            Declaration = member.Declaration;
            Documentation = member.Documentation;
            Description = member.Description;
            AppearedInVersion = member.AppearedInVersion;
            DeprecatedInVersion = member.DeprecatedInVersion;
            DisappearedInVersion = member.DisappearedInVersion;
            IsDeprecated = member.IsDeprecated;
            DeprecationMessage = member.DeprecationMessage;
            DocumentationId = member.DocumentationId;
            PendingDescription = member.PendingDescription;
            FullName = member.FullName;
            IsAbstract = member.IsAbstract;
            IsPrivate = member.IsPrivate;
            IsStatic = member.IsStatic;
            IsGetter = member.IsGetter;
            IsSetter = member.IsSetter;
        }
        #endregion

    }
}



