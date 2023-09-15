using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class MemberCodeBlockRepository : IMemberCodeBlockRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the MemberCodeBlock repository
    /// </summary>
    /// <param name="database"></param>
    public MemberCodeBlockRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_MemberCodeBlocks table
  /// </summary>
  public partial interface IMemberCodeBlockRepository
  {
  }
}

