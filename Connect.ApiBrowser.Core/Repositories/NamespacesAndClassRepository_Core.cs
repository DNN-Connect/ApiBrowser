using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.NamespacesAndClasses;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class NamespacesAndClassRepository : ServiceLocator<INamespacesAndClassRepository, NamespacesAndClassRepository>, INamespacesAndClassRepository
 {
        protected override Func<INamespacesAndClassRepository> GetFactory()
        {
            return () => new NamespacesAndClassRepository();
        }
        public IEnumerable<NamespacesAndClass> GetNamespacesAndClasses()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<NamespacesAndClass>();
                return rep.Get();
            }
        }
    }
    public partial interface INamespacesAndClassRepository
    {
        IEnumerable<NamespacesAndClass> GetNamespacesAndClasses();
    }
}

