export interface IComponent {
  ComponentId: number;
  ModuleId: number;
  ComponentName: string;
  LatestVersion: string;
}

export class Component implements IComponent {
  ComponentId: number;
  ModuleId: number;
  ComponentName: string;
  LatestVersion: string;
    constructor() {
  this.ComponentId = -1;
  this.ModuleId = -1;
  this.ComponentName = "";
  this.LatestVersion = "";
   }
}

