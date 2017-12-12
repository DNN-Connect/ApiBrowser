
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Members
{
    [TableName("Connect_ApiBrowser_Members")]
    [PrimaryKey("MemberId", AutoIncrement = true)]
    [DataContract]
    public partial class MemberBase     {

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
        #endregion

        #region Methods
        public void ReadMemberBase(MemberBase member)
        {
            if (member.MemberId > -1)
                MemberId = member.MemberId;

            if (member.ClassId > -1)
                ClassId = member.ClassId;

            if (member.MemberType > -1)
                MemberType = member.MemberType;

            if (!String.IsNullOrEmpty(member.MemberName))
                MemberName = member.MemberName;

            if (!String.IsNullOrEmpty(member.Declaration))
                Declaration = member.Declaration;

            if (!String.IsNullOrEmpty(member.Documentation))
                Documentation = member.Documentation;

            if (!String.IsNullOrEmpty(member.Description))
                Description = member.Description;

            if (!String.IsNullOrEmpty(member.AppearedInVersion))
                AppearedInVersion = member.AppearedInVersion;

            if (!String.IsNullOrEmpty(member.DeprecatedInVersion))
                DeprecatedInVersion = member.DeprecatedInVersion;

            if (!String.IsNullOrEmpty(member.DisappearedInVersion))
                DisappearedInVersion = member.DisappearedInVersion;

            IsDeprecated = member.IsDeprecated;

            if (!String.IsNullOrEmpty(member.DeprecationMessage))
                DeprecationMessage = member.DeprecationMessage;

        }
        #endregion

    }
}



