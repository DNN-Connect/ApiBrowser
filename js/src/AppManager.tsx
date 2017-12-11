import * as React from "react";
import * as ReactDOM from "react-dom";
import * as $ from "jquery";
import * as Models from './Models/';
import DataService from "./Service";

export class AppManager {
    public static Modules = new Models.KeyedCollection<Models.AppModule>();
    public static loadData(): void {
        $('.connectapibrowser').each(function (i, el) {
            var moduleId = $(el).data('moduleid');
            AppManager.Modules.Add(moduleId, new Models.AppModule(moduleId, $(el).data('tabid'), $(el).data('locale'), $(el).data('resources'), $(el).data('security'), new DataService(moduleId)));
        });
    }
}