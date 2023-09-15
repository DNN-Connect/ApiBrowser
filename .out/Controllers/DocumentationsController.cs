using Connect.ApiBrowser.Core.Models.Documentations;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class DocumentationsController
 {

  public static Documentation GetDocumentation(int documentationId)
  {

    DocumentationRepository repo = new DocumentationRepository();
    return repo.GetById(documentationId);

  }

  public static int AddDocumentation(ref DocumentationBase documentation, int userId)
 {

  documentation.SetAddingUser(userId);
   DocumentationBaseRepository repo = new DocumentationBaseRepository();
   repo.Insert(documentation);
   return documentation.DocumentationId;

  }

  public static void UpdateDocumentation(DocumentationBase documentation, int userId)
  {

   documentation.SetModifyingUser(userId);
   DocumentationBaseRepository repo = new DocumentationBaseRepository();
   repo.Update(documentation);

  }

  public static void DeleteDocumentation(DocumentationBase documentation)
  {

   DocumentationBaseRepository repo = new DocumentationBaseRepository();
   repo.Delete(documentation);

  }

 }
}
