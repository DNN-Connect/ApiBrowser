using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class ComponentRepository : IComponentRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the Component repository
    /// </summary>
    /// <param name="database"></param>
    public ComponentRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_Components table
  /// </summary>
  public partial interface IComponentRepository
  {
  }
}

