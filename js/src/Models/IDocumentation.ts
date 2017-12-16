export interface IDocumentation {
  DocumentationId: number;
  ClassId: number;
  MemberId: number;
  Contents: string;
  FullQualifier: string;
  CreatedByUserDisplayName: string;
  CreatedByUserEmail: string;
  LastModifiedByUserDisplayName: string;
  LastModifiedByUserEmail: string;
}

export class Documentation implements IDocumentation {
  DocumentationId: number;
  ClassId: number;
  MemberId: number;
  Contents: string;
  FullQualifier: string;
  CreatedByUserDisplayName: string;
  CreatedByUserEmail: string;
  LastModifiedByUserDisplayName: string;
  LastModifiedByUserEmail: string;
    constructor() {
  this.DocumentationId = -1;
  this.ClassId = -1;
  this.MemberId = -1;
  this.Contents = "";
  this.CreatedByUserDisplayName = "";
  this.LastModifiedByUserDisplayName = "";
   }
}

