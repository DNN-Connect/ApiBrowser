export interface IDocumentation {
  DocumentationId: number;
  ModuleId: number;
  FullName: string;
  Contents: string;
  IsCurrentVersion?: boolean;
  CreatedByUserDisplayName: string;
  CreatedByUserEmail: string;
  LastModifiedByUserDisplayName: string;
  LastModifiedByUserEmail: string;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
}

export class Documentation implements IDocumentation {
  DocumentationId: number;
  ModuleId: number;
  FullName: string;
  Contents: string;
  IsCurrentVersion?: boolean;
  CreatedByUserDisplayName: string;
  CreatedByUserEmail: string;
  LastModifiedByUserDisplayName: string;
  LastModifiedByUserEmail: string;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
  constructor() {
    this.DocumentationId = -1;
  this.ModuleId = -1;
  this.FullName = "";
    this.Contents = "";
    this.CreatedByUserDisplayName = "";
    this.LastModifiedByUserDisplayName = "";
    this.CreatedByUserID = -1;
    this.CreatedOnDate = new Date();
    this.LastModifiedByUserID = -1;
    this.LastModifiedOnDate = new Date();
  }
}

