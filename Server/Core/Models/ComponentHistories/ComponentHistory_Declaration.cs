
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
            if (componentHistory.ComponentHistoryId > -1)
                ComponentHistoryId = componentHistory.ComponentHistoryId;

            if (componentHistory.ComponentId > -1)
                ComponentId = componentHistory.ComponentId;

            if (!String.IsNullOrEmpty(componentHistory.Version))
                Version = componentHistory.Version;

            if (!String.IsNullOrEmpty(componentHistory.VersionNormalized))
                VersionNormalized = componentHistory.VersionNormalized;

            if (!String.IsNullOrEmpty(componentHistory.FullName))
                FullName = componentHistory.FullName;

            if (componentHistory.CodeLines > -1)
                CodeLines = componentHistory.CodeLines;

            if (componentHistory.CommentLines > -1)
                CommentLines = componentHistory.CommentLines;

            if (componentHistory.EmptyLines > -1)
                EmptyLines = componentHistory.EmptyLines;

        }
        #endregion

    }
}



