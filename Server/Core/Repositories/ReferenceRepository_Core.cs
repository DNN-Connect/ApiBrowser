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
        protected override Func<IReferenceRepository> GetFactory()
        {
            return () => new ReferenceRepository();
        }
        public IEnumerable<Reference> GetReferences()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Reference>();
                return rep.Get();
            }
        }
        public IEnumerable<Reference> GetReferencesByMemberCodeBlock(int codeBlockId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Reference>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_References WHERE CodeBlockId=@0",
                    codeBlockId);
            }
        }
        public Reference GetReference(int referenceId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Reference>();
                return rep.GetById(referenceId);
            }
        }
        public int AddReference(ref ReferenceBase reference)
        {
            Requires.NotNull(reference);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ReferenceBase>();
                rep.Insert(reference);
            }
            return reference.ReferenceId;
        }
        public void DeleteReference(ReferenceBase reference)
        {
            Requires.NotNull(reference);
            Requires.PropertyNotNegative(reference, "ReferenceId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ReferenceBase>();
                rep.Delete(reference);
            }
        }
        public void DeleteReference(int referenceId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ReferenceBase>();
                rep.Delete("WHERE ReferenceId = @0", referenceId);
            }
        }
        public void UpdateReference(ReferenceBase reference)
        {
            Requires.NotNull(reference);
            Requires.PropertyNotNegative(reference, "ReferenceId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ReferenceBase>();
                rep.Update(reference);
            }
        } 
    }
    public partial interface IReferenceRepository
    {
        IEnumerable<Reference> GetReferences();
        IEnumerable<Reference> GetReferencesByMemberCodeBlock(int codeBlockId);
        Reference GetReference(int referenceId);
        int AddReference(ref ReferenceBase reference);
        void DeleteReference(ReferenceBase reference);
        void DeleteReference(int referenceId);
        void UpdateReference(ReferenceBase reference);
    }
}

