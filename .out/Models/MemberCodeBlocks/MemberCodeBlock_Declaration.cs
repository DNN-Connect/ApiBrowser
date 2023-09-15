using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.MemberCodeBlocks
{
    [TableName("Connect_ApiBrowser_MemberCodeBlocks")]
    [PrimaryKey("CodeBlockId", AutoIncrement = true)]
    [DataContract]
    public partial class MemberCodeBlock     {

        #region .ctor
        public MemberCodeBlock()
        {
            CodeBlockId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int CodeBlockId { get; set; }
        [DataMember]
        public int MemberId { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string CodeHash { get; set; }
        [DataMember]
        public int? StartLine { get; set; }
        [DataMember]
        public int? StartColumn { get; set; }
        [DataMember]
        public int? EndLine { get; set; }
        [DataMember]
        public int? EndColumn { get; set; }
        [DataMember]
        public string FileName { get; set; }
        #endregion

        #region Methods
        public void ReadMemberCodeBlock(MemberCodeBlock memberCodeBlock)
        {
            CodeBlockId = memberCodeBlock.CodeBlockId;
            MemberId = memberCodeBlock.MemberId;
            Version = memberCodeBlock.Version;
            CodeHash = memberCodeBlock.CodeHash;
            StartLine = memberCodeBlock.StartLine;
            StartColumn = memberCodeBlock.StartColumn;
            EndLine = memberCodeBlock.EndLine;
            EndColumn = memberCodeBlock.EndColumn;
            FileName = memberCodeBlock.FileName;
        }
        #endregion

    }
}



