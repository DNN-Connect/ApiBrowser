using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Documentations;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class DocumentationRepository : ServiceLocator<IDocumentationRepository, DocumentationRepository>, IDocumentationRepository
    {
        public IEnumerable<Documentation> GetDocumentations(int classId, int memberId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Documentation>();
                return rep.Find("WHERE ClassId=@0 AND MemberId=@1", classId, memberId);
            }
        }
    }
    public partial interface IDocumentationRepository
    {
        IEnumerable<Documentation> GetDocumentations(int classId, int memberId);
    }
}

