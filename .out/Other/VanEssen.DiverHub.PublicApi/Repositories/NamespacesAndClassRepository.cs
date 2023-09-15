using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class NamespacesAndClassRepository : INamespacesAndClassRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the NamespacesAndClass repository
    /// </summary>
    /// <param name="database"></param>
    public NamespacesAndClassRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_NamespacesAndClasses table
  /// </summary>
  public partial interface INamespacesAndClassRepository
  {
  }
}

