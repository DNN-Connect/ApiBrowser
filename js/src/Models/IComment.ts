export interface IComment {
  CommentID: number;
  ComponentId: number;
  ItemType: number;
  ItemId: number;
  ParentId?: number;
  Message: string;
  Approved?: boolean;
}

export class Comment implements IComment {
  CommentID: number;
  ComponentId: number;
  ItemType: number;
  ItemId: number;
  ParentId?: number;
  Message: string;
  Approved?: boolean;
    constructor() {
  this.CommentID = -1;
  this.ComponentId = -1;
  this.ItemType = -1;
  this.ItemId = -1;
  this.Message = "";
   }
}

