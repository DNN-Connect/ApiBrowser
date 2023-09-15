using Connect.ApiBrowser.Core.Models.ApiClasses;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class ApiClassesController
 {

  public static ApiClass GetApiClass(int classId)
  {

    ApiClassRepository repo = new ApiClassRepository();
    return repo.GetById(classId);

  }

  public static int AddApiClass(ref ApiClassBase apiClass, int userId)
 {

  apiClass.SetAddingUser(userId);
   ApiClassBaseRepository repo = new ApiClassBaseRepository();
   repo.Insert(apiClass);
   return apiClass.ClassId;

  }

  public static void UpdateApiClass(ApiClassBase apiClass, int userId)
  {

   apiClass.SetModifyingUser(userId);
   ApiClassBaseRepository repo = new ApiClassBaseRepository();
   repo.Update(apiClass);

  }

  public static void DeleteApiClass(ApiClassBase apiClass)
  {

   ApiClassBaseRepository repo = new ApiClassBaseRepository();
   repo.Delete(apiClass);

  }

 }
}
