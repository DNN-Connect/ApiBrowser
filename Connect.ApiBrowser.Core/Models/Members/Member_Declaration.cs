
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
        public string ClassName { get; set; }
        [DataMember]
        public string NamespaceName { get; set; }
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
            res.ClassName = ClassName;
            res.NamespaceName = NamespaceName;
            res.ComponentName = ComponentName;
            res.LatestVersion = LatestVersion;
            res.CodeBlockCount = CodeBlockCount;
            return res;
        }
        #endregion

    }
}
