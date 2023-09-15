using Connect.ApiBrowser.Core.Models.Comments;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class CommentsController
 {

  public static Comment GetComment(int commentID)
  {

    CommentRepository repo = new CommentRepository();
    return repo.GetById(commentID);

  }

  public static int AddComment(ref CommentBase comment, int userId)
 {

  comment.SetAddingUser(userId);
   CommentBaseRepository repo = new CommentBaseRepository();
   repo.Insert(comment);
   return comment.CommentID;

  }

  public static void UpdateComment(CommentBase comment, int userId)
  {

   comment.SetModifyingUser(userId);
   CommentBaseRepository repo = new CommentBaseRepository();
   repo.Update(comment);

  }

  public static void DeleteComment(CommentBase comment)
  {

   CommentBaseRepository repo = new CommentBaseRepository();
   repo.Delete(comment);

  }

 }
}
