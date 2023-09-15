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
        public IEnumerable<Documentation> GetDocumentations(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Documentation>();
                return rep.Get(moduleId);
            }
        }
        public Documentation GetDocumentation(int moduleId, int documentationId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Documentation>();
                return rep.GetById(documentationId, moduleId);
            }
        }
        public DocumentationBase AddDocumentation(DocumentationBase documentation, int userId)
        {
            Requires.NotNull(documentation);
            Requires.PropertyNotNegative(documentation, "ModuleId");
            documentation.CreatedByUserID = userId;
            documentation.CreatedOnDate = DateTime.Now;
            documentation.LastModifiedByUserID = userId;
            documentation.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DocumentationBase>();
                rep.Insert(documentation);
            }
            return documentation;
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
        public void DeleteDocumentation(int moduleId, int documentationId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DocumentationBase>();
                rep.Delete("WHERE ModuleId = @0 AND DocumentationId = @1", moduleId, documentationId);
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
        IEnumerable<Documentation> GetDocumentations(int moduleId);
        Documentation GetDocumentation(int moduleId, int documentationId);
        DocumentationBase AddDocumentation(DocumentationBase documentation, int userId);
        void DeleteDocumentation(DocumentationBase documentation);
        void DeleteDocumentation(int moduleId, int documentationId);
        void UpdateDocumentation(DocumentationBase documentation, int userId);
    }
}

