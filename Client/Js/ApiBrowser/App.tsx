import { AppManager } from "./AppManager";
import { ComponentLoader } from "./ComponentLoader";

document.addEventListener("DOMContentLoaded", function () {
  AppManager.loadData();
  ComponentLoader.load();
});
