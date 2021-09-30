export interface IMemberCodeBlock {
  CodeBlockId: number;
  MemberId: number;
  Version: string;
  CodeHash: string;
  StartLine?: number;
  StartColumn?: number;
  EndLine?: number;
  EndColumn?: number;
  FileName: string;
}

export class MemberCodeBlock implements IMemberCodeBlock {
  CodeBlockId: number;
  MemberId: number;
  Version: string;
  CodeHash: string;
  StartLine?: number;
  StartColumn?: number;
  EndLine?: number;
  EndColumn?: number;
  FileName: string;
    constructor() {
  this.CodeBlockId = -1;
  this.MemberId = -1;
  this.Version = "";
  this.CodeHash = "";
   }
}

