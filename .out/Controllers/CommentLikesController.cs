using Connect.ApiBrowser.Core.Models.CommentLikes;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class CommentLikesController
 {


  public static void UpdateCommentLike(CommentLikeBase commentLike)
  {

   CommentLikeBaseRepository repo = new CommentLikeBaseRepository();
   repo.Update(commentLike);

  }

  public static void DeleteCommentLike(CommentLikeBase commentLike)
  {

   CommentLikeBaseRepository repo = new CommentLikeBaseRepository();
   repo.Delete(commentLike);

  }

 }
}
