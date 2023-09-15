using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class DependencyRepository : IDependencyRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the Dependency repository
    /// </summary>
    /// <param name="database"></param>
    public DependencyRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_Dependencies table
  /// </summary>
  public partial interface IDependencyRepository
  {
  }
}

