using Connect.ApiBrowser.Core.Models.Dependencies;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class DependenciesController
 {

  public static Dependency GetDependency(int dependencyId)
  {

    DependencyRepository repo = new DependencyRepository();
    return repo.GetById(dependencyId);

  }

  public static int AddDependency(ref DependencyBase dependency)
 {
   DependencyBaseRepository repo = new DependencyBaseRepository();
   repo.Insert(dependency);
   return dependency.DependencyId;

  }

  public static void UpdateDependency(DependencyBase dependency)
  {

   DependencyBaseRepository repo = new DependencyBaseRepository();
   repo.Update(dependency);

  }

  public static void DeleteDependency(DependencyBase dependency)
  {

   DependencyBaseRepository repo = new DependencyBaseRepository();
   repo.Delete(dependency);

  }

 }
}
