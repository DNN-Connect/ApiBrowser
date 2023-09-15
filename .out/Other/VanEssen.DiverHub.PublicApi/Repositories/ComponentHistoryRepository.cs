using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class ComponentHistoryRepository : IComponentHistoryRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the ComponentHistory repository
    /// </summary>
    /// <param name="database"></param>
    public ComponentHistoryRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_ComponentHistories table
  /// </summary>
  public partial interface IComponentHistoryRepository
  {
  }
}

