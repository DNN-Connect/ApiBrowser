using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class MemberCodeBlockRepository : ServiceLocator<IMemberCodeBlockRepository, MemberCodeBlockRepository>, IMemberCodeBlockRepository
 {
        protected override Func<IMemberCodeBlockRepository> GetFactory()
        {
            return () => new MemberCodeBlockRepository();
        }
        public IEnumerable<MemberCodeBlock> GetMemberCodeBlocks()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberCodeBlock>();
                return rep.Get();
            }
        }
        public IEnumerable<MemberCodeBlock> GetMemberCodeBlocksByMember(int memberId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<MemberCodeBlock>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_MemberCodeBlocks WHERE MemberId=@0",
                    memberId);
            }
        }
        public MemberCodeBlock GetMemberCodeBlock(int codeBlockId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberCodeBlock>();
                return rep.GetById(codeBlockId);
            }
        }
        public MemberCodeBlock AddMemberCodeBlock(MemberCodeBlock memberCodeBlock)
        {
            Requires.NotNull(memberCodeBlock);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberCodeBlock>();
                rep.Insert(memberCodeBlock);
            }
            return memberCodeBlock;
        }
        public void DeleteMemberCodeBlock(MemberCodeBlock memberCodeBlock)
        {
            Requires.NotNull(memberCodeBlock);
            Requires.PropertyNotNegative(memberCodeBlock, "MemberCodeBlockId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberCodeBlock>();
                rep.Delete(memberCodeBlock);
            }
        }
        public void DeleteMemberCodeBlock(int codeBlockId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberCodeBlock>();
                rep.Delete("WHERE CodeBlockId = @0", codeBlockId);
            }
        }
        public void UpdateMemberCodeBlock(MemberCodeBlock memberCodeBlock)
        {
            Requires.NotNull(memberCodeBlock);
            Requires.PropertyNotNegative(memberCodeBlock, "MemberCodeBlockId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberCodeBlock>();
                rep.Update(memberCodeBlock);
            }
        } 
    }
    public partial interface IMemberCodeBlockRepository
    {
        IEnumerable<MemberCodeBlock> GetMemberCodeBlocks();
        IEnumerable<MemberCodeBlock> GetMemberCodeBlocksByMember(int memberId);
        MemberCodeBlock GetMemberCodeBlock(int codeBlockId);
        MemberCodeBlock AddMemberCodeBlock(MemberCodeBlock memberCodeBlock);
        void DeleteMemberCodeBlock(MemberCodeBlock memberCodeBlock);
        void DeleteMemberCodeBlock(int codeBlockId);
        void UpdateMemberCodeBlock(MemberCodeBlock memberCodeBlock);
    }
}

