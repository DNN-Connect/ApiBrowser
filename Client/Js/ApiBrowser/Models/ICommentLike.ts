export interface ICommentLike {
  CommentId: number;
  UserId: number;
  Datime: Date;
}

export class CommentLike implements ICommentLike {
  CommentId: number;
  UserId: number;
  Datime: Date;
    constructor() {
  this.CommentId = -1;
  this.UserId = -1;
  this.Datime = new Date();
   }
}

