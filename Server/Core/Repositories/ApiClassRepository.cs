using System.Linq;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ApiClasses;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class ApiClassRepository : ServiceLocator<IApiClassRepository, ApiClassRepository>, IApiClassRepository
    {
        public ApiClass GetApiClass(int moduleId, string fullName)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ApiClass>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_ApiBrowser_ApiClasses WHERE ModuleId=@0 AND FullQualifier=@1",
                    moduleId, fullName).FirstOrDefault();
            }
        }
    }
    public partial interface IApiClassRepository
    {
        ApiClass GetApiClass(int moduleId, string fullName);
    }
}

