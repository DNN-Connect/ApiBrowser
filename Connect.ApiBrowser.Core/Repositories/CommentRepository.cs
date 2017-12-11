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
    }
    public partial interface ICommentRepository
    {
    }
}

