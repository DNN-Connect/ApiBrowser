import * as React from "react";
import * as ReactDOM from "react-dom";
import * as $ from "jquery";
import { AppManager } from "./AppManager";
import { ComponentLoader } from "./ComponentLoader";

var modules = {};

$(document).ready(function () {
  AppManager.loadData();
  ComponentLoader.load();
});
