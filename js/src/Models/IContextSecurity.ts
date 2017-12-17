export interface IContextSecurity {
    CanView: boolean;
    CanEdit: boolean;
    CanComment: boolean;
    CanModerate: boolean;
    IsAdmin: boolean;
    UserId: number;
}