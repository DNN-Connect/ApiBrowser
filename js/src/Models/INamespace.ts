export interface INamespace {
  NamespaceId: number;
  ModuleId?: number;
  NamespaceName: string;
}

export class Namespace implements INamespace {
  NamespaceId: number;
  ModuleId?: number;
  NamespaceName: string;
    constructor() {
  this.NamespaceId = -1;
  this.NamespaceName = "";
   }
}

