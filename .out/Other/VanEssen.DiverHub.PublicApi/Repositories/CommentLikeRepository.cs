using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class CommentLikeRepository : ICommentLikeRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the CommentLike repository
    /// </summary>
    /// <param name="database"></param>
    public CommentLikeRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_CommentLikes table
  /// </summary>
  public partial interface ICommentLikeRepository
  {
  }
}

