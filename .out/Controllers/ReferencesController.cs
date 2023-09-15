using Connect.ApiBrowser.Core.Models.References;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class ReferencesController
 {

  public static Reference GetReference(int referenceId)
  {

    ReferenceRepository repo = new ReferenceRepository();
    return repo.GetById(referenceId);

  }

  public static int AddReference(ref ReferenceBase reference)
 {
   ReferenceBaseRepository repo = new ReferenceBaseRepository();
   repo.Insert(reference);
   return reference.ReferenceId;

  }

  public static void UpdateReference(ReferenceBase reference)
  {

   ReferenceBaseRepository repo = new ReferenceBaseRepository();
   repo.Update(reference);

  }

  public static void DeleteReference(ReferenceBase reference)
  {

   ReferenceBaseRepository repo = new ReferenceBaseRepository();
   repo.Delete(reference);

  }

 }
}
