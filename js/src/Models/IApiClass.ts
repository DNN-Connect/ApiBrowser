export interface IApiClass {
  ClassId: number;
  NamespaceId: number;
  ComponentId?: number;
  ClassName: string;
  Declaration: string;
  Documentation: string;
  AppearedInVersion: string;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
  IsDeprecated: boolean;
  DeprecationMessage: string;
  NamespaceName: string;
  ComponentName: string;
  LatestVersion: string;
  MemberCount?: number;
}

export class ApiClass implements IApiClass {
  ClassId: number;
  NamespaceId: number;
  ComponentId?: number;
  ClassName: string;
  Declaration: string;
  Documentation: string;
  AppearedInVersion: string;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
  IsDeprecated: boolean;
  DeprecationMessage: string;
  NamespaceName: string;
  ComponentName: string;
  LatestVersion: string;
  MemberCount?: number;
    constructor() {
  this.ClassId = -1;
  this.NamespaceId = -1;
  this.ClassName = "";
  this.AppearedInVersion = "";
  this.IsDeprecated = false;
  this.NamespaceName = "";
  this.ComponentName = "";
  this.LatestVersion = "";
   }
}

