
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
            if (dependency.DependencyId > -1)
                DependencyId = dependency.DependencyId;

            if (dependency.ComponentHistoryId > -1)
                ComponentHistoryId = dependency.ComponentHistoryId;

            if (!String.IsNullOrEmpty(dependency.FullName))
                FullName = dependency.FullName;

            if (!String.IsNullOrEmpty(dependency.Version))
                Version = dependency.Version;

            if (!String.IsNullOrEmpty(dependency.VersionNormalized))
                VersionNormalized = dependency.VersionNormalized;

            if (!String.IsNullOrEmpty(dependency.Name))
                Name = dependency.Name;

            if (dependency.DepComponentHistoryId > -1)
                DepComponentHistoryId = dependency.DepComponentHistoryId;

        }
        #endregion

    }
}



