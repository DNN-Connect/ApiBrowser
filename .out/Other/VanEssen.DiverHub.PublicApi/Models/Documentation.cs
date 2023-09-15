using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_Documentations")]
    [PrimaryKey("DocumentationId", AutoIncrement = true)]
    public partial class Documentation
    {

        public int DocumentationId { get; set; }
        public int ModuleId { get; set; }
        public string FullName { get; set; }
        public string Contents { get; set; }
        public bool? IsCurrentVersion { get; set; }
        public string CreatedByUserDisplayName { get; set; }
        public string CreatedByUserEmail { get; set; }
        public string LastModifiedByUserDisplayName { get; set; }
        public string LastModifiedByUserEmail { get; set; }
    }
}
