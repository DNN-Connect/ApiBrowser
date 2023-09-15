using Connect.ApiBrowser.Core.Models.NamespacesAndClasses;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class NamespacesAndClassesController
 {


  public static void UpdateNamespacesAndClass(NamespacesAndClassBase namespacesAndClass)
  {

   NamespacesAndClassBaseRepository repo = new NamespacesAndClassBaseRepository();
   repo.Update(namespacesAndClass);

  }

  public static void DeleteNamespacesAndClass(NamespacesAndClassBase namespacesAndClass)
  {

   NamespacesAndClassBaseRepository repo = new NamespacesAndClassBaseRepository();
   repo.Delete(namespacesAndClass);

  }

 }
}
