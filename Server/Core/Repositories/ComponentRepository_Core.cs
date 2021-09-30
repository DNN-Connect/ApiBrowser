using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Components;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class ComponentRepository : ServiceLocator<IComponentRepository, ComponentRepository>, IComponentRepository
 {
        protected override Func<IComponentRepository> GetFactory()
        {
            return () => new ComponentRepository();
        }
        public IEnumerable<Component> GetComponents(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Component>();
                return rep.Get(moduleId);
            }
        }
        public Component GetComponent(int moduleId, int componentId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Component>();
                return rep.GetById(componentId, moduleId);
            }
        }
        public int AddComponent(ref Component component)
        {
            Requires.NotNull(component);
            Requires.PropertyNotNegative(component, "ModuleId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Component>();
                rep.Insert(component);
            }
            return component.ComponentId;
        }
        public void DeleteComponent(Component component)
        {
            Requires.NotNull(component);
            Requires.PropertyNotNegative(component, "ComponentId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Component>();
                rep.Delete(component);
            }
        }
        public void DeleteComponent(int moduleId, int componentId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Component>();
                rep.Delete("WHERE ModuleId = @0 AND ComponentId = @1", moduleId, componentId);
            }
        }
        public void UpdateComponent(Component component)
        {
            Requires.NotNull(component);
            Requires.PropertyNotNegative(component, "ComponentId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Component>();
                rep.Update(component);
            }
        } 
    }
    public partial interface IComponentRepository
    {
        IEnumerable<Component> GetComponents(int moduleId);
        Component GetComponent(int moduleId, int componentId);
        int AddComponent(ref Component component);
        void DeleteComponent(Component component);
        void DeleteComponent(int moduleId, int componentId);
        void UpdateComponent(Component component);
    }
}

