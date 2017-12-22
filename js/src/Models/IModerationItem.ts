export interface IModerationItem {
    DocType: number;
    ClassId: number;
    MemberId: number;
    DocumentationId: number;
    FullQualifier: string;
    OldText: string;
    NewText: string;
    LastModifiedOnDate: Date;
    LastModifiedByUserDisplayName: string;
}

export class ModerationItem {
    DocType: number;
    ClassId: number;
    MemberId: number;
    DocumentationId: number;
    FullQualifier: string;
    OldText: string;
    NewText: string;
    LastModifiedOnDate: Date;
    LastModifiedByUserDisplayName: string;
}