using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Members;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class MemberRepository : ServiceLocator<IMemberRepository, MemberRepository>, IMemberRepository
 {
        protected override Func<IMemberRepository> GetFactory()
        {
            return () => new MemberRepository();
        }
        public IEnumerable<Member> GetMembers()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Member>();
                return rep.Get();
            }
        }
        public IEnumerable<Member> GetMembersByApiClass(int classId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Member>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_Members WHERE ClassId=@0",
                    classId);
            }
        }
        public Member GetMember(int memberId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Member>();
                return rep.GetById(memberId);
            }
        }
        public MemberBase AddMember(MemberBase member, int userId)
        {
            Requires.NotNull(member);
            member.CreatedByUserID = userId;
            member.CreatedOnDate = DateTime.Now;
            member.LastModifiedByUserID = userId;
            member.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberBase>();
                rep.Insert(member);
            }
            return member;
        }
        public void DeleteMember(MemberBase member)
        {
            Requires.NotNull(member);
            Requires.PropertyNotNegative(member, "MemberId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberBase>();
                rep.Delete(member);
            }
        }
        public void DeleteMember(int memberId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberBase>();
                rep.Delete("WHERE MemberId = @0", memberId);
            }
        }
        public void UpdateMember(MemberBase member, int userId)
        {
            Requires.NotNull(member);
            Requires.PropertyNotNegative(member, "MemberId");
            member.LastModifiedByUserID = userId;
            member.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<MemberBase>();
                rep.Update(member);
            }
        } 
    }
    public partial interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        IEnumerable<Member> GetMembersByApiClass(int classId);
        Member GetMember(int memberId);
        MemberBase AddMember(MemberBase member, int userId);
        void DeleteMember(MemberBase member);
        void DeleteMember(int memberId);
        void UpdateMember(MemberBase member, int userId);
    }
}

