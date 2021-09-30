
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
            if (memberCodeBlock.CodeBlockId > -1)
                CodeBlockId = memberCodeBlock.CodeBlockId;

            if (memberCodeBlock.MemberId > -1)
                MemberId = memberCodeBlock.MemberId;

            if (!String.IsNullOrEmpty(memberCodeBlock.Version))
                Version = memberCodeBlock.Version;

            if (!String.IsNullOrEmpty(memberCodeBlock.CodeHash))
                CodeHash = memberCodeBlock.CodeHash;

            if (memberCodeBlock.StartLine > -1)
                StartLine = memberCodeBlock.StartLine;

            if (memberCodeBlock.StartColumn > -1)
                StartColumn = memberCodeBlock.StartColumn;

            if (memberCodeBlock.EndLine > -1)
                EndLine = memberCodeBlock.EndLine;

            if (memberCodeBlock.EndColumn > -1)
                EndColumn = memberCodeBlock.EndColumn;

            if (!String.IsNullOrEmpty(memberCodeBlock.FileName))
                FileName = memberCodeBlock.FileName;

        }
        #endregion

    }
}



