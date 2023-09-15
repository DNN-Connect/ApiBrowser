using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.MemberCodeBlocks
{
    public partial class MemberCodeBlock
 {
        public List<LogChange> CompareWith(MemberCodeBlock memberCodeBlock)
        {
      var res = new List<LogChange>();
            if (CodeBlockId != memberCodeBlock.CodeBlockId)
        res.Add(new LogChange("CodeBlockId",this.CodeBlockId, memberCodeBlock.CodeBlockId));
            if (MemberId != memberCodeBlock.MemberId)
        res.Add(new LogChange("MemberId",this.MemberId, memberCodeBlock.MemberId));
            if (Version != memberCodeBlock.Version)
        res.Add(new LogChange("Version",this.Version, memberCodeBlock.Version));
            if (CodeHash != memberCodeBlock.CodeHash)
        res.Add(new LogChange("CodeHash",this.CodeHash, memberCodeBlock.CodeHash));
            if (StartLine != memberCodeBlock.StartLine)
        res.Add(new LogChange("StartLine",this.StartLine, memberCodeBlock.StartLine));
            if (StartColumn != memberCodeBlock.StartColumn)
        res.Add(new LogChange("StartColumn",this.StartColumn, memberCodeBlock.StartColumn));
            if (EndLine != memberCodeBlock.EndLine)
        res.Add(new LogChange("EndLine",this.EndLine, memberCodeBlock.EndLine));
            if (EndColumn != memberCodeBlock.EndColumn)
        res.Add(new LogChange("EndColumn",this.EndColumn, memberCodeBlock.EndColumn));
            if (FileName != memberCodeBlock.FileName)
        res.Add(new LogChange("FileName",this.FileName, memberCodeBlock.FileName));

            return res;
        }
 }
}

