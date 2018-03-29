export interface IReference {
  ReferenceId: number;
  CodeBlockId: number;
  FullName: string;
  Offset: number;
  ReferencedMemberId?: number;
  MemberName: string;
  AppearedInVersion: string;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
}

export class Reference implements IReference {
  ReferenceId: number;
  CodeBlockId: number;
  FullName: string;
  Offset: number;
  ReferencedMemberId?: number;
  MemberName: string;
  AppearedInVersion: string;
  DeprecatedInVersion: string;
  DisappearedInVersion: string;
    constructor() {
  this.ReferenceId = -1;
  this.CodeBlockId = -1;
  this.FullName = "";
  this.Offset = -1;
   }
}

