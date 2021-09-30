using System;
using System.Collections.Generic;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.CommentLikes;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class CommentLikeRepository : ServiceLocator<ICommentLikeRepository, CommentLikeRepository>, ICommentLikeRepository
 {
        protected override Func<ICommentLikeRepository> GetFactory()
        {
            return () => new CommentLikeRepository();
        }
        public IEnumerable<CommentLike> GetCommentLikesByComment(int commentId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<CommentLike>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_CommentLikes WHERE CommentId=@0",
                    commentId);
            }
        }
        public CommentLike GetCommentLike(int commentId, int userId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<CommentLike>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_CommentLikes WHERE CommentId=@0 AND UserId=@1",
                    commentId,userId);
            }
        }
        public void AddCommentLike(CommentLike commentLike)
        {
            Requires.NotNull(commentLike);
            Requires.NotNull(commentLike.CommentId);
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "IF NOT EXISTS (SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_CommentLikes " +
                    "WHERE CommentId=@0 AND UserId=@1) " +
                    "INSERT INTO {databaseOwner}{objectQualifier}Connect_ApiBrowser_CommentLikes (CommentId, UserId, Datime) " +
                    "SELECT @0, @1, @2", commentLike.CommentId, commentLike.UserId, commentLike.Datime);
            }
        }
        public void DeleteCommentLike(CommentLike commentLike)
        {
            DeleteCommentLike(commentLike.CommentId, commentLike.UserId);
        }
        public void DeleteCommentLike(int commentId, int userId)
        {
             Requires.NotNull(commentId);
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_CommentLikes WHERE CommentId=@0 AND UserId=@1",
                    commentId,userId);
            }
        }
        public void DeleteCommentLikesByComment(int commentId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_CommentLikes WHERE CommentId=@0",
                    commentId);
            }
        }
        public void UpdateCommentLike(CommentLike commentLike)
        {
            Requires.NotNull(commentLike);
            Requires.NotNull(commentLike.CommentId);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<CommentLike>();
                rep.Update("SET Datime=@0 WHERE CommentId=@1 AND UserId=@2",
                          commentLike.Datime, commentLike.CommentId,commentLike.UserId);
            }
        } 
 }

    public partial interface ICommentLikeRepository
    {
        IEnumerable<CommentLike> GetCommentLikesByComment(int commentId);
        CommentLike GetCommentLike(int commentId, int userId);
        void AddCommentLike(CommentLike commentLike);
        void DeleteCommentLike(CommentLike commentLike);
        void DeleteCommentLike(int commentId, int userId);
        void DeleteCommentLikesByComment(int commentId);
        void UpdateCommentLike(CommentLike commentLike);
    }
}

