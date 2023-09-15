using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ApiClasses;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class ApiClassRepository : ServiceLocator<IApiClassRepository, ApiClassRepository>, IApiClassRepository
 {
        protected override Func<IApiClassRepository> GetFactory()
        {
            return () => new ApiClassRepository();
        }
        public IEnumerable<ApiClass> GetApiClasses()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiClass>();
                return rep.Get();
            }
        }
        public IEnumerable<ApiClass> GetApiClassesByApiNamespace(int namespaceId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ApiClass>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_ApiClasses WHERE NamespaceId=@0",
                    namespaceId);
            }
        }
        public IEnumerable<ApiClass> GetApiClassesByComponent(int componentId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ApiClass>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_ApiClasses WHERE ComponentId=@0",
                    componentId);
            }
        }
        public ApiClass GetApiClass(int classId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiClass>();
                return rep.GetById(classId);
            }
        }
        public ApiClassBase AddApiClass(ApiClassBase apiClass, int userId)
        {
            Requires.NotNull(apiClass);
            apiClass.CreatedByUserID = userId;
            apiClass.CreatedOnDate = DateTime.Now;
            apiClass.LastModifiedByUserID = userId;
            apiClass.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiClassBase>();
                rep.Insert(apiClass);
            }
            return apiClass;
        }
        public void DeleteApiClass(ApiClassBase apiClass)
        {
            Requires.NotNull(apiClass);
            Requires.PropertyNotNegative(apiClass, "ApiClassId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiClassBase>();
                rep.Delete(apiClass);
            }
        }
        public void DeleteApiClass(int classId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiClassBase>();
                rep.Delete("WHERE ClassId = @0", classId);
            }
        }
        public void UpdateApiClass(ApiClassBase apiClass, int userId)
        {
            Requires.NotNull(apiClass);
            Requires.PropertyNotNegative(apiClass, "ApiClassId");
            apiClass.LastModifiedByUserID = userId;
            apiClass.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiClassBase>();
                rep.Update(apiClass);
            }
        } 
    }
    public partial interface IApiClassRepository
    {
        IEnumerable<ApiClass> GetApiClasses();
        IEnumerable<ApiClass> GetApiClassesByApiNamespace(int namespaceId);
        IEnumerable<ApiClass> GetApiClassesByComponent(int componentId);
        ApiClass GetApiClass(int classId);
        ApiClassBase AddApiClass(ApiClassBase apiClass, int userId);
        void DeleteApiClass(ApiClassBase apiClass);
        void DeleteApiClass(int classId);
        void UpdateApiClass(ApiClassBase apiClass, int userId);
    }
}

