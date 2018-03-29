using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Dependencies;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class DependencyRepository : ServiceLocator<IDependencyRepository, DependencyRepository>, IDependencyRepository
 {
        protected override Func<IDependencyRepository> GetFactory()
        {
            return () => new DependencyRepository();
        }
        public IEnumerable<Dependency> GetDependencies()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Dependency>();
                return rep.Get();
            }
        }
        public IEnumerable<Dependency> GetDependenciesByComponentHistory(int componentHistoryId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Dependency>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_Dependencies WHERE ComponentHistoryId=@0",
                    componentHistoryId);
            }
        }
        public Dependency GetDependency(int dependencyId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Dependency>();
                return rep.GetById(dependencyId);
            }
        }
        public int AddDependency(ref DependencyBase dependency)
        {
            Requires.NotNull(dependency);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DependencyBase>();
                rep.Insert(dependency);
            }
            return dependency.DependencyId;
        }
        public void DeleteDependency(DependencyBase dependency)
        {
            Requires.NotNull(dependency);
            Requires.PropertyNotNegative(dependency, "DependencyId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DependencyBase>();
                rep.Delete(dependency);
            }
        }
        public void DeleteDependency(int dependencyId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DependencyBase>();
                rep.Delete("WHERE DependencyId = @0", dependencyId);
            }
        }
        public void UpdateDependency(DependencyBase dependency)
        {
            Requires.NotNull(dependency);
            Requires.PropertyNotNegative(dependency, "DependencyId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<DependencyBase>();
                rep.Update(dependency);
            }
        } 
    }
    public partial interface IDependencyRepository
    {
        IEnumerable<Dependency> GetDependencies();
        IEnumerable<Dependency> GetDependenciesByComponentHistory(int componentHistoryId);
        Dependency GetDependency(int dependencyId);
        int AddDependency(ref DependencyBase dependency);
        void DeleteDependency(DependencyBase dependency);
        void DeleteDependency(int dependencyId);
        void UpdateDependency(DependencyBase dependency);
    }
}

