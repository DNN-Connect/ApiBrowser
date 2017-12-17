export interface IDocumentation {
  DocumentationId: number;
  ClassId: number;
  MemberId: number;
  Contents: string;
  FullQualifier: string;
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
  ClassId: number;
  MemberId: number;
  Contents: string;
  FullQualifier: string;
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
    this.ClassId = -1;
    this.MemberId = -1;
    this.Contents = "";
    this.CreatedByUserDisplayName = "";
    this.LastModifiedByUserDisplayName = "";
    this.CreatedByUserID = -1;
    this.CreatedOnDate = new Date();
    this.LastModifiedByUserID = -1;
    this.LastModifiedOnDate = new Date();
  }
}

