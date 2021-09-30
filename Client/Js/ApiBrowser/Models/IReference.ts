export interface IReference {
  ReferenceId: number;
  CodeBlockId: number;
  FullName: string;
  Offset: number;
  ReferencedMemberId?: number;
  FromRefMemberId: number;
  FromRefStartLine?: number;
  FromRefEndLine?: number;
  FromRefMemberName: string;
  FromRefFullName: string;
  FromRefAppearedInVersion: string;
  FromRefDeprecatedInVersion: string;
  FromRefDisappearedInVersion: string;
  FromRefClassId: number;
  FromRefClassName: string;
  FromRefFullQualifier: string;
  ToRefMemberName: string;
  ToRefFullName: string;
  ToRefAppearedInVersion: string;
  ToRefDeprecatedInVersion: string;
  ToRefDisappearedInVersion: string;
}

export class Reference implements IReference {
  ReferenceId: number;
  CodeBlockId: number;
  FullName: string;
  Offset: number;
  ReferencedMemberId?: number;
  FromRefMemberId: number;
  FromRefStartLine?: number;
  FromRefEndLine?: number;
  FromRefMemberName: string;
  FromRefFullName: string;
  FromRefAppearedInVersion: string;
  FromRefDeprecatedInVersion: string;
  FromRefDisappearedInVersion: string;
  FromRefClassId: number;
  FromRefClassName: string;
  FromRefFullQualifier: string;
  ToRefMemberName: string;
  ToRefFullName: string;
  ToRefAppearedInVersion: string;
  ToRefDeprecatedInVersion: string;
  ToRefDisappearedInVersion: string;
    constructor() {
  this.ReferenceId = -1;
  this.CodeBlockId = -1;
  this.FullName = "";
  this.Offset = -1;
  this.FromRefMemberId = -1;
  this.FromRefMemberName = "";
  this.FromRefFullName = "";
  this.FromRefAppearedInVersion = "";
  this.FromRefClassId = -1;
  this.FromRefClassName = "";
  this.FromRefFullQualifier = "";
   }
}

