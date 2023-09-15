using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class MemberRepository : IMemberRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the Member repository
    /// </summary>
    /// <param name="database"></param>
    public MemberRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_Members table
  /// </summary>
  public partial interface IMemberRepository
  {
  }
}

