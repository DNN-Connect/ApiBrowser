export interface IDependency {
  DependencyId: number;
  ComponentHistoryId: number;
  FullName: string;
  Version: string;
  VersionNormalized: string;
  Name: string;
  DepComponentHistoryId?: number;
  ComponentName: string;
  LatestVersion: string;
  DependentComponentName: string;
}

export class Dependency implements IDependency {
  DependencyId: number;
  ComponentHistoryId: number;
  FullName: string;
  Version: string;
  VersionNormalized: string;
  Name: string;
  DepComponentHistoryId?: number;
  ComponentName: string;
  LatestVersion: string;
  DependentComponentName: string;
    constructor() {
  this.DependencyId = -1;
  this.ComponentHistoryId = -1;
  this.FullName = "";
  this.Version = "";
  this.VersionNormalized = "";
  this.Name = "";
  this.ComponentName = "";
  this.LatestVersion = "";
   }
}

