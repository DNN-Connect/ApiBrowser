using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class DocumentationRepository : IDocumentationRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the Documentation repository
    /// </summary>
    /// <param name="database"></param>
    public DocumentationRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_Documentations table
  /// </summary>
  public partial interface IDocumentationRepository
  {
  }
}

