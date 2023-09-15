using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class ApiClassRepository : IApiClassRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the ApiClass repository
    /// </summary>
    /// <param name="database"></param>
    public ApiClassRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_ApiClasses table
  /// </summary>
  public partial interface IApiClassRepository
  {
  }
}

