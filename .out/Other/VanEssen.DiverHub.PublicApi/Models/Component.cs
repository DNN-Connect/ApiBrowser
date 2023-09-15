using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("Connect_ApiBrowser_Components")]
    [PrimaryKey("ComponentId", AutoIncrement = true)]
    public partial class Component
    {

        public int ComponentId { get; set; }
        public int ModuleId { get; set; }
        public string ComponentName { get; set; }
        public string LatestVersion { get; set; }
        public string Description { get; set; }
    }
}
