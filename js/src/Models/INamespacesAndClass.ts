export interface INamespacesAndClass {
  ModuleId: number;
  NamespaceId: number;
  ClassId: number;
  IsClass?: boolean;
  Name: string;
  Description: string;
  IsDeprecated: number;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
}

export class NamespacesAndClass implements INamespacesAndClass {
  ModuleId: number;
  NamespaceId: number;
  ClassId: number;
  IsClass?: boolean;
  Name: string;
  Description: string;
  IsDeprecated: number;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
    constructor() {
  this.ModuleId = -1;
  this.NamespaceId = -1;
  this.ClassId = -1;
  this.Name = "";
  this.IsDeprecated = -1;
   }
}

