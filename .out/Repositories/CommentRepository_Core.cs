using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Comments;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class CommentRepository : ServiceLocator<ICommentRepository, CommentRepository>, ICommentRepository
 {
        protected override Func<ICommentRepository> GetFactory()
        {
            return () => new CommentRepository();
        }
        public IEnumerable<Comment> GetComments()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Comment>();
                return rep.Get();
            }
        }
        public IEnumerable<Comment> GetCommentsByComponent(int componentId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Comment>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_Comments WHERE ComponentId=@0",
                    componentId);
            }
        }
        public Comment GetComment(int commentID)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Comment>();
                return rep.GetById(commentID);
            }
        }
        public Comment AddComment(Comment comment, int userId)
        {
            Requires.NotNull(comment);
            comment.CreatedByUserID = userId;
            comment.CreatedOnDate = DateTime.Now;
            comment.LastModifiedByUserID = userId;
            comment.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Comment>();
                rep.Insert(comment);
            }
            return comment;
        }
        public void DeleteComment(Comment comment)
        {
            Requires.NotNull(comment);
            Requires.PropertyNotNegative(comment, "CommentId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Comment>();
                rep.Delete(comment);
            }
        }
        public void DeleteComment(int commentID)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Comment>();
                rep.Delete("WHERE CommentID = @0", commentID);
            }
        }
        public void UpdateComment(Comment comment, int userId)
        {
            Requires.NotNull(comment);
            Requires.PropertyNotNegative(comment, "CommentId");
            comment.LastModifiedByUserID = userId;
            comment.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Comment>();
                rep.Update(comment);
            }
        } 
    }
    public partial interface ICommentRepository
    {
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetCommentsByComponent(int componentId);
        Comment GetComment(int commentID);
        Comment AddComment(Comment comment, int userId);
        void DeleteComment(Comment comment);
        void DeleteComment(int commentID);
        void UpdateComment(Comment comment, int userId);
    }
}

