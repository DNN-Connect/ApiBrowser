
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
            if (reference.ReferenceId > -1)
                ReferenceId = reference.ReferenceId;

            if (reference.CodeBlockId > -1)
                CodeBlockId = reference.CodeBlockId;

            if (!String.IsNullOrEmpty(reference.FullName))
                FullName = reference.FullName;

            if (reference.Offset > -1)
                Offset = reference.Offset;

            if (reference.ReferencedMemberId > -1)
                ReferencedMemberId = reference.ReferencedMemberId;

        }
        #endregion

    }
}



