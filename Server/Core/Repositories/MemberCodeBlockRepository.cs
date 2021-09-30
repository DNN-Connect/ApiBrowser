using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class MemberCodeBlockRepository : ServiceLocator<IMemberCodeBlockRepository, MemberCodeBlockRepository>, IMemberCodeBlockRepository
    {
        public MemberCodeBlock GetMemberCodeBlock(int memberId, string version)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<MemberCodeBlock>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_MemberCodeBlocks WHERE MemberId=@0 AND Version=@1",
                    memberId, version);
            }
        }
    }
    public partial interface IMemberCodeBlockRepository
    {
        MemberCodeBlock GetMemberCodeBlock(int memberId, string version);
    }
}

