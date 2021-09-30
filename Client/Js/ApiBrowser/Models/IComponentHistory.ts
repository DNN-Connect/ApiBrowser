export interface IComponentHistory {
  ComponentHistoryId: number;
  ComponentId: number;
  Version: string;
  VersionNormalized: string;
  FullName: string;
  CodeLines: number;
  CommentLines?: number;
  EmptyLines?: number;
}

export class ComponentHistory implements IComponentHistory {
  ComponentHistoryId: number;
  ComponentId: number;
  Version: string;
  VersionNormalized: string;
  FullName: string;
  CodeLines: number;
  CommentLines?: number;
  EmptyLines?: number;
    constructor() {
  this.ComponentHistoryId = -1;
  this.ComponentId = -1;
  this.Version = "";
  this.VersionNormalized = "";
  this.FullName = "";
  this.CodeLines = -1;
   }
}

