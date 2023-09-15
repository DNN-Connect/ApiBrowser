using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class ApiNamespacesController
 {

  public static ApiNamespace GetApiNamespace(int namespaceId)
  {

    ApiNamespaceRepository repo = new ApiNamespaceRepository();
    return repo.GetById(namespaceId);

  }

  public static int AddApiNamespace(ref ApiNamespaceBase apiNamespace)
 {
   ApiNamespaceBaseRepository repo = new ApiNamespaceBaseRepository();
   repo.Insert(apiNamespace);
   return apiNamespace.NamespaceId;

  }

  public static void UpdateApiNamespace(ApiNamespaceBase apiNamespace)
  {

   ApiNamespaceBaseRepository repo = new ApiNamespaceBaseRepository();
   repo.Update(apiNamespace);

  }

  public static void DeleteApiNamespace(ApiNamespaceBase apiNamespace)
  {

   ApiNamespaceBaseRepository repo = new ApiNamespaceBaseRepository();
   repo.Delete(apiNamespace);

  }

 }
}
