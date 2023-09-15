using Connect.ApiBrowser.Core.Models.NamespacesClassesAndMembers;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class NamespacesClassesAndMembersController
 {


  public static void UpdateNamespacesClassesAndMember(NamespacesClassesAndMemberBase namespacesClassesAndMember)
  {

   NamespacesClassesAndMemberBaseRepository repo = new NamespacesClassesAndMemberBaseRepository();
   repo.Update(namespacesClassesAndMember);

  }

  public static void DeleteNamespacesClassesAndMember(NamespacesClassesAndMemberBase namespacesClassesAndMember)
  {

   NamespacesClassesAndMemberBaseRepository repo = new NamespacesClassesAndMemberBaseRepository();
   repo.Delete(namespacesClassesAndMember);

  }

 }
}
