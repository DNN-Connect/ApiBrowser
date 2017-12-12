import * as React from "react";
import * as ReactDOM from "react-dom";
import * as $ from "jquery";
import { AppManager } from "./AppManager";
import Browser from "./Components/Browser/Browser";
import FileManager from "./Components/Files/FileManager";

export class ComponentLoader {

  public static load(): void {
    $('.apibrowser').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<Browser
        module={AppManager.Modules.Item(moduleId.toString())}
        selection={$(el).data('selection')}
        classes={$(el).data('classes')}
        />, el);
    });
    $('.filemanager').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<FileManager
        module={AppManager.Modules.Item(moduleId.toString())}
        />, el);
    });

  }
}