export interface IApiNamespace {
  NamespaceId: number;
  ParentId: number;
  ModuleId: number;
  NamespaceName: string;
  LastQualifier: string;
}

export class ApiNamespace implements IApiNamespace {
  NamespaceId: number;
  ParentId: number;
  ModuleId: number;
  NamespaceName: string;
  LastQualifier: string;
    constructor() {
  this.NamespaceId = -1;
  this.ParentId = -1;
  this.ModuleId = -1;
  this.NamespaceName = "";
  this.LastQualifier = "";
   }
}

