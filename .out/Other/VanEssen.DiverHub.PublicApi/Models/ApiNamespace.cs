using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("Connect_ApiBrowser_ApiNamespaces")]
    [PrimaryKey("NamespaceId", AutoIncrement = true)]
    public partial class ApiNamespace
    {

        public int NamespaceId { get; set; }
        public int ParentId { get; set; }
        public int ModuleId { get; set; }
        public string NamespaceName { get; set; }
        public string LastQualifier { get; set; }
        public string Description { get; set; }
    }
}
