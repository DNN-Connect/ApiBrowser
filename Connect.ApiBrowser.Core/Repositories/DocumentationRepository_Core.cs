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
        protected override Func<IDocumentationRepository> GetFactory()
        {
            return () => new DocumentationRepository();
        }
        public IEnumerable<Documentation> GetDocumentations()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Documentation>();
                return rep.Get();
            }
        }
        public Documentation GetDocumentation(int documentationId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Documentation>();
                return rep.GetById(documentationId);
            }
        }
        public int AddDocumentation(ref DocumentationBase documentation, int userId)
        {
            Requires.NotNull(documentation);
            documentation.CreatedByUserID = userId;
            documentation.CreatedOnDate = DateTime.Now;
            documentation.LastModifiedByUserID = userId;
            documentation.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DocumentationBase>();
                rep.Insert(documentation);
            }
            return documentation.DocumentationId;
        }
        public void DeleteDocumentation(DocumentationBase documentation)
        {
            Requires.NotNull(documentation);
            Requires.PropertyNotNegative(documentation, "DocumentationId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DocumentationBase>();
                rep.Delete(documentation);
            }
        }
        public void DeleteDocumentation(int documentationId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DocumentationBase>();
                rep.Delete("WHERE DocumentationId = @0", documentationId);
            }
        }
        public void UpdateDocumentation(DocumentationBase documentation, int userId)
        {
            Requires.NotNull(documentation);
            Requires.PropertyNotNegative(documentation, "DocumentationId");
            documentation.LastModifiedByUserID = userId;
            documentation.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DocumentationBase>();
                rep.Update(documentation);
            }
        } 
    }
    public partial interface IDocumentationRepository
    {
        IEnumerable<Documentation> GetDocumentations();
        Documentation GetDocumentation(int documentationId);
        int AddDocumentation(ref DocumentationBase documentation, int userId);
        void DeleteDocumentation(DocumentationBase documentation);
        void DeleteDocumentation(int documentationId);
        void UpdateDocumentation(DocumentationBase documentation, int userId);
    }
}

