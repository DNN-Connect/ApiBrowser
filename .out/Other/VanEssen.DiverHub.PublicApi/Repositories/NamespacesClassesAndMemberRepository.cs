using Connect.ApiBrowser.Core.PublicApi.Data;
using Connect.ApiBrowser.Core.PublicApi.Models;

namespace Connect.ApiBrowser.Core.PublicApi.Repositories
{
  /// <inheritdoc />
  public partial class NamespacesClassesAndMemberRepository : INamespacesClassesAndMemberRepository
  {
    private readonly IDatabase _database;
    /// <summary>
    /// Create a new instance of the NamespacesClassesAndMember repository
    /// </summary>
    /// <param name="database"></param>
    public NamespacesClassesAndMemberRepository(IDatabase database)
    {
      _database = database;
    }

  }
  /// <summary>
  /// Access DH_NamespacesClassesAndMembers table
  /// </summary>
  public partial interface INamespacesClassesAndMemberRepository
  {
  }
}

