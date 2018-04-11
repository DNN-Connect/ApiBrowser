using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.References;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class ReferenceRepository : ServiceLocator<IReferenceRepository, ReferenceRepository>, IReferenceRepository
    {
        public IEnumerable<Reference> GetReferencesToMember(int memberId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Reference>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_References WHERE ReferencedMemberId=@0",
                    memberId);
            }
        }
    }
    public partial interface IReferenceRepository
    {
        IEnumerable<Reference> GetReferencesToMember(int memberId);
    }
}

