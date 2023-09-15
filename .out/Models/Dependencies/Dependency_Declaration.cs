using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.Dependencies
{

    [TableName("vw_Connect_ApiBrowser_Dependencies")]
    [PrimaryKey("DependencyId", AutoIncrement = true)]
    [DataContract]
    public partial class Dependency  : DependencyBase 
    {

        #region .ctor
        public Dependency()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public string LatestVersion { get; set; }
        [DataMember]
        public string DependentComponentName { get; set; }
        #endregion

        #region Methods
        public DependencyBase GetDependencyBase()
        {
            DependencyBase res = new DependencyBase();
             res.DependencyId = DependencyId;
             res.ComponentHistoryId = ComponentHistoryId;
             res.FullName = FullName;
             res.Version = Version;
             res.VersionNormalized = VersionNormalized;
             res.Name = Name;
             res.DepComponentHistoryId = DepComponentHistoryId;
            return res;
        }
        public Dependency Clone()
        {
            Dependency res = new Dependency();
            res.DependencyId = DependencyId;
            res.ComponentHistoryId = ComponentHistoryId;
            res.FullName = FullName;
            res.Version = Version;
            res.VersionNormalized = VersionNormalized;
            res.Name = Name;
            res.DepComponentHistoryId = DepComponentHistoryId;
            res.ComponentName = ComponentName;
            res.LatestVersion = LatestVersion;
            res.DependentComponentName = DependentComponentName;
            return res;
        }
        #endregion

    }
}
