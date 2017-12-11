import * as React from "react";
import * as ReactDOM from "react-dom";
import * as $ from "jquery";
import Browser from "./Components/Browser/Browser";
import { AppManager } from "./AppManager";

export class ComponentLoader {

  public static load(): void {
    $('.apibrowser').each(function (i, el) {
      var moduleId = $(el).data('moduleid');
      ReactDOM.render(<Browser
        module={AppManager.Modules.Item(moduleId.toString())}
        />, el);
    });

  }
}