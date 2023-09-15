using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.References
{
    [TableName("Connect_ApiBrowser_References")]
    [PrimaryKey("ReferenceId", AutoIncrement = true)]
    [DataContract]
    public partial class ReferenceBase     {

        #region .ctor
        public ReferenceBase()
        {
            ReferenceId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ReferenceId { get; set; }
        [DataMember]
        public int CodeBlockId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public int Offset { get; set; }
        [DataMember]
        public int? ReferencedMemberId { get; set; }
        #endregion

        #region Methods
        public void ReadReferenceBase(ReferenceBase reference)
        {
            ReferenceId = reference.ReferenceId;
            CodeBlockId = reference.CodeBlockId;
            FullName = reference.FullName;
            Offset = reference.Offset;
            ReferencedMemberId = reference.ReferencedMemberId;
        }
        #endregion

    }
}



