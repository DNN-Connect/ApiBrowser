
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.References
{

    [TableName("vw_Connect_ApiBrowser_References")]
    [PrimaryKey("ReferenceId", AutoIncrement = true)]
    [DataContract]
    public partial class Reference  : ReferenceBase 
    {

        #region .ctor
        public Reference()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public int FromRefMemberId { get; set; }
        [DataMember]
        public int? FromRefStartLine { get; set; }
        [DataMember]
        public int? FromRefEndLine { get; set; }
        [DataMember]
        public string FromRefMemberName { get; set; }
        [DataMember]
        public string FromRefFullName { get; set; }
        [DataMember]
        public string FromRefAppearedInVersion { get; set; }
        [DataMember]
        public string FromRefDeprecatedInVersion { get; set; }
        [DataMember]
        public string FromRefDisappearedInVersion { get; set; }
        [DataMember]
        public int FromRefClassId { get; set; }
        [DataMember]
        public string FromRefClassName { get; set; }
        [DataMember]
        public string FromRefFullQualifier { get; set; }
        [DataMember]
        public string ToRefMemberName { get; set; }
        [DataMember]
        public string ToRefFullName { get; set; }
        [DataMember]
        public string ToRefAppearedInVersion { get; set; }
        [DataMember]
        public string ToRefDeprecatedInVersion { get; set; }
        [DataMember]
        public string ToRefDisappearedInVersion { get; set; }
        #endregion

        #region Methods
        public ReferenceBase GetReferenceBase()
        {
            ReferenceBase res = new ReferenceBase();
             res.ReferenceId = ReferenceId;
             res.CodeBlockId = CodeBlockId;
             res.FullName = FullName;
             res.Offset = Offset;
             res.ReferencedMemberId = ReferencedMemberId;
            return res;
        }
        public Reference Clone()
        {
            Reference res = new Reference();
            res.ReferenceId = ReferenceId;
            res.CodeBlockId = CodeBlockId;
            res.FullName = FullName;
            res.Offset = Offset;
            res.ReferencedMemberId = ReferencedMemberId;
            res.FromRefMemberId = FromRefMemberId;
            res.FromRefStartLine = FromRefStartLine;
            res.FromRefEndLine = FromRefEndLine;
            res.FromRefMemberName = FromRefMemberName;
            res.FromRefFullName = FromRefFullName;
            res.FromRefAppearedInVersion = FromRefAppearedInVersion;
            res.FromRefDeprecatedInVersion = FromRefDeprecatedInVersion;
            res.FromRefDisappearedInVersion = FromRefDisappearedInVersion;
            res.FromRefClassId = FromRefClassId;
            res.FromRefClassName = FromRefClassName;
            res.FromRefFullQualifier = FromRefFullQualifier;
            res.ToRefMemberName = ToRefMemberName;
            res.ToRefFullName = ToRefFullName;
            res.ToRefAppearedInVersion = ToRefAppearedInVersion;
            res.ToRefDeprecatedInVersion = ToRefDeprecatedInVersion;
            res.ToRefDisappearedInVersion = ToRefDisappearedInVersion;
            return res;
        }
        #endregion

    }
}
