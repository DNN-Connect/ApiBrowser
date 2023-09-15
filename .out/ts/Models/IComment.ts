export interface IComment {
  CommentID: number;
  ComponentId: number;
  ItemType: number;
  ItemId: number;
  ParentId?: number;
  Message: string;
  Approved?: boolean;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
}

export class Comment implements IComment {
  CommentID: number;
  ComponentId: number;
  ItemType: number;
  ItemId: number;
  ParentId?: number;
  Message: string;
  Approved?: boolean;
  CreatedByUserID: number;
  CreatedOnDate: Date;
  LastModifiedByUserID: number;
  LastModifiedOnDate: Date;
    constructor() {
  this.CommentID = -1;
  this.ComponentId = -1;
  this.ItemType = -1;
  this.ItemId = -1;
  this.Message = "";
  this.CreatedByUserID = -1;
  this.CreatedOnDate = new Date();
  this.LastModifiedByUserID = -1;
  this.LastModifiedOnDate = new Date();
   }
}

