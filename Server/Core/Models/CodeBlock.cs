using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Connect.ApiBrowser.Core.Models
{
    public class CodeBlock
    {
        [IgnoreDataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string Hash { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public int StartLine { get; set; }
        [DataMember]
        public int StartColumn { get; set; }
        [DataMember]
        public int EndLine { get; set; }
        [DataMember]
        public int EndColumn { get; set; }
        public static CodeBlock FromXmlBlock(int moduleId, XmlNode codeNode)
        {
            var res = new CodeBlock()
            {
                ModuleId = moduleId,
                Body = codeNode.SelectSingleNode("body").InnerText,
                Hash = codeNode.SelectSingleNode("body").Attributes["hash"].InnerText,
                EndColumn = int.Parse(codeNode.SelectSingleNode("location").Attributes["ec"].InnerText),
                EndLine = int.Parse(codeNode.SelectSingleNode("location").Attributes["el"].InnerText),
                StartColumn = int.Parse(codeNode.SelectSingleNode("location").Attributes["sc"].InnerText),
                StartLine = int.Parse(codeNode.SelectSingleNode("location").Attributes["sl"].InnerText),
                FileName = codeNode.SelectSingleNode("location").InnerText
            };
            return res;
        }
        public bool IsPresentIn(IEnumerable<MemberCodeBlock> codeblocks)
        {
            foreach (var mcb in codeblocks)
            {
                if (mcb.CodeHash == Hash && mcb.StartLine == StartLine && mcb.FileName == FileName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
