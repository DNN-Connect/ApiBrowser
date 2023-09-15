using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class ApiNamespaceRepository : IApiNamespaceRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the ApiNamespace repository
    /// </summary>
    /// <param name="database"></param>
    public ApiNamespaceRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_ApiNamespaces table
  /// </summary>
  public partial interface IApiNamespaceRepository
  {
  }
}

