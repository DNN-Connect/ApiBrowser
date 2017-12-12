
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Components
{
    [TableName("Connect_ApiBrowser_Components")]
    [PrimaryKey("ComponentId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class Component     {

        #region .ctor
        public Component()
        {
            ComponentId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public string LatestVersion { get; set; }
        [DataMember]
        public string Description { get; set; }
        #endregion

        #region Methods
        public void ReadComponent(Component component)
        {
            if (component.ComponentId > -1)
                ComponentId = component.ComponentId;

            if (component.ModuleId > -1)
                ModuleId = component.ModuleId;

            if (!String.IsNullOrEmpty(component.ComponentName))
                ComponentName = component.ComponentName;

            if (!String.IsNullOrEmpty(component.LatestVersion))
                LatestVersion = component.LatestVersion;

            if (!String.IsNullOrEmpty(component.Description))
                Description = component.Description;

        }
        #endregion

    }
}



