using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Dependencies
{
    [TableName("Connect_ApiBrowser_Dependencies")]
    [PrimaryKey("DependencyId", AutoIncrement = true)]
    [DataContract]
    public partial class DependencyBase     {

        #region .ctor
        public DependencyBase()
        {
            DependencyId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int DependencyId { get; set; }
        [DataMember]
        public int ComponentHistoryId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string VersionNormalized { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? DepComponentHistoryId { get; set; }
        #endregion

        #region Methods
        public void ReadDependencyBase(DependencyBase dependency)
        {
            DependencyId = dependency.DependencyId;
            ComponentHistoryId = dependency.ComponentHistoryId;
            FullName = dependency.FullName;
            Version = dependency.Version;
            VersionNormalized = dependency.VersionNormalized;
            Name = dependency.Name;
            DepComponentHistoryId = dependency.DepComponentHistoryId;
        }
        #endregion

    }
}



