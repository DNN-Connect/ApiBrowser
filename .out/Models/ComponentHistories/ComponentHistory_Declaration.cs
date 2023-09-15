using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.ComponentHistories
{
    [TableName("Connect_ApiBrowser_ComponentHistories")]
    [PrimaryKey("ComponentHistoryId", AutoIncrement = true)]
    [DataContract]
    public partial class ComponentHistory     {

        #region .ctor
        public ComponentHistory()
        {
            ComponentHistoryId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ComponentHistoryId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string VersionNormalized { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public int CodeLines { get; set; }
        [DataMember]
        public int? CommentLines { get; set; }
        [DataMember]
        public int? EmptyLines { get; set; }
        #endregion

        #region Methods
        public void ReadComponentHistory(ComponentHistory componentHistory)
        {
            ComponentHistoryId = componentHistory.ComponentHistoryId;
            ComponentId = componentHistory.ComponentId;
            Version = componentHistory.Version;
            VersionNormalized = componentHistory.VersionNormalized;
            FullName = componentHistory.FullName;
            CodeLines = componentHistory.CodeLines;
            CommentLines = componentHistory.CommentLines;
            EmptyLines = componentHistory.EmptyLines;
        }
        #endregion

    }
}



