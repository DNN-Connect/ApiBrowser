import DataService from "./Service";
import { KeyedCollection } from "./Models/IKeyedCollection";
import { AppModule } from "./Models/IAppModule";

export class AppManager {
  public static Modules = new KeyedCollection<AppModule>();
  public static loadData(): void {
    $(".connectapibrowser").each(function (i, el) {
      var moduleId = $(el).data("moduleid");
      AppManager.Modules.Add(
        moduleId,
        new AppModule(
          moduleId,
          $(el).data("tabid"),
          $(el).data("locale"),
          $(el).data("resources"),
          $(el).data("security"),
          new DataService(moduleId)
        )
      );
    });
  }
}
