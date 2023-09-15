export interface ICommentLike {
  CommentId: number;
  UserId: number;
  Datime: string;
}

export class CommentLike implements ICommentLike {
  CommentId: number;
  UserId: number;
  Datime: string;
    constructor() {
  this.CommentId = -1;
  this.UserId = -1;
  this.Datime = "";
   }
}

