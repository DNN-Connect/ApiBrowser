export interface INamespacesClassesAndMember {
  ModuleId: number;
  NamespaceId: number;
  ClassId: number;
  MemberId: number;
  MainType: number;
  SubType: number;
  Name: string;
  Description: string;
  PendingDescription: string;
  IsDeprecated: number;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
  LastModifiedByUserID?: number;
  LastModifiedOnDate?: string;
}

export class NamespacesClassesAndMember implements INamespacesClassesAndMember {
  ModuleId: number;
  NamespaceId: number;
  ClassId: number;
  MemberId: number;
  MainType: number;
  SubType: number;
  Name: string;
  Description: string;
  PendingDescription: string;
  IsDeprecated: number;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
  LastModifiedByUserID?: number;
  LastModifiedOnDate?: string;
    constructor() {
  this.ModuleId = -1;
  this.NamespaceId = -1;
  this.ClassId = -1;
  this.MemberId = -1;
  this.MainType = -1;
  this.SubType = -1;
  this.Name = "";
  this.IsDeprecated = -1;
   }
}

