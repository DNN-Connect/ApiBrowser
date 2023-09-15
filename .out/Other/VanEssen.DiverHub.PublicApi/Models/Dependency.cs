using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_Dependencies")]
    [PrimaryKey("DependencyId", AutoIncrement = true)]
    public partial class Dependency
    {

        public int DependencyId { get; set; }
        public int ComponentHistoryId { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }
        public string VersionNormalized { get; set; }
        public string Name { get; set; }
        public int? DepComponentHistoryId { get; set; }
        public string ComponentName { get; set; }
        public string LatestVersion { get; set; }
        public string DependentComponentName { get; set; }
    }
}
