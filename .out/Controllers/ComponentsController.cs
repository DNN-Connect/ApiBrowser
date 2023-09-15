using Connect.ApiBrowser.Core.Models.Components;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class ComponentsController
 {

  public static Component GetComponent(int componentId)
  {

    ComponentRepository repo = new ComponentRepository();
    return repo.GetById(componentId);

  }

  public static int AddComponent(ref ComponentBase component)
 {
   ComponentBaseRepository repo = new ComponentBaseRepository();
   repo.Insert(component);
   return component.ComponentId;

  }

  public static void UpdateComponent(ComponentBase component)
  {

   ComponentBaseRepository repo = new ComponentBaseRepository();
   repo.Update(component);

  }

  public static void DeleteComponent(ComponentBase component)
  {

   ComponentBaseRepository repo = new ComponentBaseRepository();
   repo.Delete(component);

  }

 }
}
