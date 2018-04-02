import * as React from "react";
import * as ReactDOM from "react-dom";
import * as $ from "jquery";
import { AppManager } from "./AppManager";
import NamespaceBrowser from "./Components/ClassesAndNamespaces/NamespaceBrowser";
import FileManager from "./Components/Files/FileManager";
import ClassesAndNamespacesGrid from "./Components/ClassesAndNamespaces/Grid";
import DocumentationEditor from "./Components/Editor/DocumentationEditor";
import ModerationScreen from "./Components/Moderation/ModerationScreen";
import Browser from "./Components/Browser/Browser";

export class ComponentLoader {

  public static load(): void {
    $('.apibrowser').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<Browser
        module={AppManager.Modules.Item(moduleId.toString())}
        detailLink={$(el).data('detail-link')}
        />, el);
    });
    $('.nsbrowser').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<NamespaceBrowser
        module={AppManager.Modules.Item(moduleId.toString())}
        selection={$(el).data('selection')}
        classes={$(el).data('classes')}
        documentationLink={$(el).data('documentation-link')}
        />, el);
    });
    $('.filemanager').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<FileManager
        module={AppManager.Modules.Item(moduleId.toString())}
        />, el);
    });
    $('.classesandnamespaces').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<ClassesAndNamespacesGrid
        module={AppManager.Modules.Item(moduleId.toString())}
        detailLink={$(el).data('detail-link')}
        />, el);
    });
    $('.documentationeditor').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<DocumentationEditor
        module={AppManager.Modules.Item(moduleId.toString())}
        history={$(el).data('history')}
        edit={$(el).data('edit')}
        currentVersion={$(el).data('current-version')}
        />, el);
    });
    $('.moderation').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<ModerationScreen
        module={AppManager.Modules.Item(moduleId.toString())}
        documentationLink={$(el).data('documentation-link')}
        />, el);
    });

  }
}