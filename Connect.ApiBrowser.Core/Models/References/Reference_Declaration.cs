
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
        public string MemberName { get; set; }
        [DataMember]
        public string AppearedInVersion { get; set; }
        [DataMember]
        public string DeprecatedInVersion { get; set; }
        [DataMember]
        public string DisappearedInVersion { get; set; }
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
            res.MemberName = MemberName;
            res.AppearedInVersion = AppearedInVersion;
            res.DeprecatedInVersion = DeprecatedInVersion;
            res.DisappearedInVersion = DisappearedInVersion;
            return res;
        }
        #endregion

    }
}
