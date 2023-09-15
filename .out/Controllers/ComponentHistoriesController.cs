using Connect.ApiBrowser.Core.Models.ComponentHistories;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class ComponentHistoriesController
 {

  public static ComponentHistory GetComponentHistory(int componentHistoryId)
  {

    ComponentHistoryRepository repo = new ComponentHistoryRepository();
    return repo.GetById(componentHistoryId);

  }

  public static int AddComponentHistory(ref ComponentHistoryBase componentHistory)
 {
   ComponentHistoryBaseRepository repo = new ComponentHistoryBaseRepository();
   repo.Insert(componentHistory);
   return componentHistory.ComponentHistoryId;

  }

  public static void UpdateComponentHistory(ComponentHistoryBase componentHistory)
  {

   ComponentHistoryBaseRepository repo = new ComponentHistoryBaseRepository();
   repo.Update(componentHistory);

  }

  public static void DeleteComponentHistory(ComponentHistoryBase componentHistory)
  {

   ComponentHistoryBaseRepository repo = new ComponentHistoryBaseRepository();
   repo.Delete(componentHistory);

  }

 }
}
