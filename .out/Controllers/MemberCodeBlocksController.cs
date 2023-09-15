using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.ApiBrowser.Core.Controllers
{

 public partial class MemberCodeBlocksController
 {

  public static MemberCodeBlock GetMemberCodeBlock(int codeBlockId)
  {

    MemberCodeBlockRepository repo = new MemberCodeBlockRepository();
    return repo.GetById(codeBlockId);

  }

  public static int AddMemberCodeBlock(ref MemberCodeBlockBase memberCodeBlock)
 {
   MemberCodeBlockBaseRepository repo = new MemberCodeBlockBaseRepository();
   repo.Insert(memberCodeBlock);
   return memberCodeBlock.CodeBlockId;

  }

  public static void UpdateMemberCodeBlock(MemberCodeBlockBase memberCodeBlock)
  {

   MemberCodeBlockBaseRepository repo = new MemberCodeBlockBaseRepository();
   repo.Update(memberCodeBlock);

  }

  public static void DeleteMemberCodeBlock(MemberCodeBlockBase memberCodeBlock)
  {

   MemberCodeBlockBaseRepository repo = new MemberCodeBlockBaseRepository();
   repo.Delete(memberCodeBlock);

  }

 }
}
