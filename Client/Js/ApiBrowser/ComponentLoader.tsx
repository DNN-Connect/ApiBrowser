import { AppManager } from "./AppManager";
import { render } from "solid-js/web";
import Browser from "./Components/Browser/Browser";
import Grid from "./Components/ClassesAndNamespaces/Grid";
import FileManager from "./Components/Files/FileManager";
import DocumentationEditor from "./Components/Editor/DocumentationEditor";
// import ModerationScreen from "./Components/Moderation/ModerationScreen";

export class ComponentLoader {
  public static load(): void {
    document.querySelectorAll(".apibrowser").forEach((el) => {
      var moduleId = $(el).data("moduleid");
      render(
        () => (
          <Browser
            module={AppManager.Modules.Item(moduleId.toString())}
            selection={$(el).data("selection")}
            classes={$(el).data("classes")}
            documentationLink={$(el).data("documentation-link")}
            returnLink={$(el).data("return-link")}
          />
        ),
        el
      );
    });
    document.querySelectorAll(".classesandnamespaces").forEach((el) => {
      var moduleId = $(el).data("moduleid");
      render(
        () => (
          <Grid
            module={AppManager.Modules.Item(moduleId.toString())}
            detailLink={$(el).data("detail-link")}
          />
        ),
        el
      );
    });
    document.querySelectorAll(".filemanager").forEach((el) => {
      var moduleId = $(el).data("moduleid");
      render(
        () => (
          <FileManager module={AppManager.Modules.Item(moduleId.toString())} />
        ),
        el
      );
    });
    document.querySelectorAll(".documentationeditor").forEach((el) => {
      var moduleId = $(el).data("moduleid");
      render(
        () => (
          <DocumentationEditor
            module={AppManager.Modules.Item(moduleId.toString())}
            history={$(el).data("history")}
            edit={$(el).data("edit")}
            currentVersion={$(el).data("current-version")}
          />
        ),
        el
      );
    });
  }
}
