using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ComponentHistories;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class ComponentHistoryRepository : ServiceLocator<IComponentHistoryRepository, ComponentHistoryRepository>, IComponentHistoryRepository
 {
        protected override Func<IComponentHistoryRepository> GetFactory()
        {
            return () => new ComponentHistoryRepository();
        }
        public IEnumerable<ComponentHistory> GetComponentHistories()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ComponentHistory>();
                return rep.Get();
            }
        }
        public IEnumerable<ComponentHistory> GetComponentHistoriesByComponent(int componentId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ComponentHistory>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}Connect_ApiBrowser_ComponentHistories WHERE ComponentId=@0",
                    componentId);
            }
        }
        public ComponentHistory GetComponentHistory(int componentHistoryId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ComponentHistory>();
                return rep.GetById(componentHistoryId);
            }
        }
        public ComponentHistory AddComponentHistory(ComponentHistory componentHistory)
        {
            Requires.NotNull(componentHistory);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ComponentHistory>();
                rep.Insert(componentHistory);
            }
            return componentHistory;
        }
        public void DeleteComponentHistory(ComponentHistory componentHistory)
        {
            Requires.NotNull(componentHistory);
            Requires.PropertyNotNegative(componentHistory, "ComponentHistoryId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ComponentHistory>();
                rep.Delete(componentHistory);
            }
        }
        public void DeleteComponentHistory(int componentHistoryId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ComponentHistory>();
                rep.Delete("WHERE ComponentHistoryId = @0", componentHistoryId);
            }
        }
        public void UpdateComponentHistory(ComponentHistory componentHistory)
        {
            Requires.NotNull(componentHistory);
            Requires.PropertyNotNegative(componentHistory, "ComponentHistoryId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ComponentHistory>();
                rep.Update(componentHistory);
            }
        } 
    }
    public partial interface IComponentHistoryRepository
    {
        IEnumerable<ComponentHistory> GetComponentHistories();
        IEnumerable<ComponentHistory> GetComponentHistoriesByComponent(int componentId);
        ComponentHistory GetComponentHistory(int componentHistoryId);
        ComponentHistory AddComponentHistory(ComponentHistory componentHistory);
        void DeleteComponentHistory(ComponentHistory componentHistory);
        void DeleteComponentHistory(int componentHistoryId);
        void UpdateComponentHistory(ComponentHistory componentHistory);
    }
}

