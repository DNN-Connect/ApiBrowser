export interface IClassOrMember {
    ClassId: number;
    MemberId?: number;
    Description: string;
    PendingDescription: string;
    CreatedByUserID: number;
    CreatedOnDate: Date;
    LastModifiedByUserID: number;
    LastModifiedOnDate: Date;      
}