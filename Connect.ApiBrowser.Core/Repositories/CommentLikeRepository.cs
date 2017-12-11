using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.CommentLikes;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class CommentLikeRepository : ServiceLocator<ICommentLikeRepository, CommentLikeRepository>, ICommentLikeRepository
    {
    }
    public partial interface ICommentLikeRepository
    {
    }
}

