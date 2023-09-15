using Connect.ApiBrowser.Core.Models.Members;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class MembersController
 {

  public static Member GetMember(int memberId)
  {

    MemberRepository repo = new MemberRepository();
    return repo.GetById(memberId);

  }

  public static int AddMember(ref MemberBase member, int userId)
 {

  member.SetAddingUser(userId);
   MemberBaseRepository repo = new MemberBaseRepository();
   repo.Insert(member);
   return member.MemberId;

  }

  public static void UpdateMember(MemberBase member, int userId)
  {

   member.SetModifyingUser(userId);
   MemberBaseRepository repo = new MemberBaseRepository();
   repo.Update(member);

  }

  public static void DeleteMember(MemberBase member)
  {

   MemberBaseRepository repo = new MemberBaseRepository();
   repo.Delete(member);

  }

 }
}
