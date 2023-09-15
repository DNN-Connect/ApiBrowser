using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class CommentRepository : ICommentRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the Comment repository
    /// </summary>
    /// <param name="database"></param>
    public CommentRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_Comments table
  /// </summary>
  public partial interface ICommentRepository
  {
  }
}

