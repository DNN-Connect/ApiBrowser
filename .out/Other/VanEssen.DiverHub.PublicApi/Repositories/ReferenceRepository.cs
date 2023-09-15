using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class ReferenceRepository : IReferenceRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the Reference repository
    /// </summary>
    /// <param name="database"></param>
    public ReferenceRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_References table
  /// </summary>
  public partial interface IReferenceRepository
  {
  }
}

