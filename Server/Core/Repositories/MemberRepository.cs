using System.Linq;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Members;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class MemberRepository : ServiceLocator<IMemberRepository, MemberRepository>, IMemberRepository
    {
        public Member GetMember(int moduleId, string fullName)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Member>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_Members WHERE ModuleId=@0 AND FullQualifier=@1",
                    moduleId, fullName).FirstOrDefault();
            }
        }
    }
    public partial interface IMemberRepository
    {
        Member GetMember(int moduleId, string fullName);
    }
}

