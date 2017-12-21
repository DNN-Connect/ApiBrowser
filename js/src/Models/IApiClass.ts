import { IMember } from "./IMember";

export interface IApiClass {
  ClassId: number;
  NamespaceId: number;
  ComponentId?: number;
  ClassName: string;
  Declaration: string;
  Documentation: string;
  Description: string;
  AppearedInVersion: string;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
  IsDeprecated: boolean;
  DeprecationMessage: string;
  DocumentationId?: number;
  PendingDescription: string;
  CreatedByUserDisplayName: string;
  LastModifiedByUserDisplayName: string;
  DocumentationContents: string;
  NamespaceName: string;
  FullQualifier: string;
  ModuleId: number;
  ComponentName: string;
  LatestVersion: string;
  MemberCount?: number;
  Members?: IMember[];
}

export class ApiClass implements IApiClass {
  ClassId: number;
  NamespaceId: number;
  ComponentId?: number;
  ClassName: string;
  Declaration: string;
  Documentation: string;
  Description: string;
  AppearedInVersion: string;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
  IsDeprecated: boolean;
  DeprecationMessage: string;
  DocumentationId?: number;
  PendingDescription: string;
  CreatedByUserDisplayName: string;
  LastModifiedByUserDisplayName: string;
  DocumentationContents: string;
  NamespaceName: string;
  FullQualifier: string;
  ModuleId: number;
  ComponentName: string;
  LatestVersion: string;
  MemberCount?: number;
  Members?: IMember[];
  constructor() {
    this.ClassId = -1;
    this.NamespaceId = -1;
    this.ClassName = "";
    this.AppearedInVersion = "";
    this.IsDeprecated = false;
    this.NamespaceName = "";
  this.FullQualifier = "";
  this.ModuleId = -1;
    this.ComponentName = "";
    this.LatestVersion = "";
  }
}

