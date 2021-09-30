export interface IMember {
  MemberId: number;
  ClassId: number;
  MemberType: number;
  MemberName: string;
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
  FullName: string;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  CreatedByUserDisplayName: string;
  LastModifiedByUserDisplayName: string;
  DocumentationContents: string;
  ClassName: string;
  NamespaceName: string;
  FullQualifier: string;
  ModuleId: number;
  ComponentName: string;
  LatestVersion: string;
  CodeBlockCount?: number;
}

export class Member implements IMember {
  MemberId: number;
  ClassId: number;
  MemberType: number;
  MemberName: string;
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
  FullName: string;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  CreatedByUserDisplayName: string;
  LastModifiedByUserDisplayName: string;
  DocumentationContents: string;
  ClassName: string;
  NamespaceName: string;
  FullQualifier: string;
  ModuleId: number;
  ComponentName: string;
  LatestVersion: string;
  CodeBlockCount?: number;
  constructor() {
    this.MemberId = -1;
    this.ClassId = -1;
    this.MemberType = -1;
    this.MemberName = "";
    this.AppearedInVersion = "";
    this.IsDeprecated = false;
  this.FullName = "";
  this.CreatedByUserID = -1;
  this.CreatedOnDate = new Date();
  this.LastModifiedByUserID = -1;
  this.LastModifiedOnDate = new Date();
    this.ClassName = "";
    this.NamespaceName = "";
    this.FullQualifier = "";
    this.ModuleId = -1;
    this.ComponentName = "";
    this.LatestVersion = "";
  }
}

