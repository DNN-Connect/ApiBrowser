using System.Linq;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security;
using DotNetNuke.Security.Permissions;

namespace Connect.DNN.Modules.ApiBrowser.Common
{
    public class ContextSecurity
    {
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanComment { get; set; }
        public bool CanModerate { get; set; }
        public bool IsAdmin { get; set; }
        private UserInfo user { get; set; }

        public int UserId
        {
            get
            {
                return user.UserID;
            }
        }

        public ContextSecurity(ModuleInfo objModule)
        {
            user = UserController.Instance.GetCurrentUserInfo();
            if (user.IsSuperUser)
            {
                CanView = CanEdit = CanComment = CanModerate = IsAdmin = true;
            }
            else
            {
                IsAdmin = PortalSecurity.IsInRole(PortalSettings.Current.AdministratorRoleName);
                if (IsAdmin)
                {
                    CanView = CanEdit = CanComment = CanModerate = true;
                }
                else
                {
                    CanView = ModulePermissionController.CanViewModule(objModule);
                    CanEdit = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, "EDIT");
                    CanComment = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, "COMMENT");
                    CanModerate = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, "MODERATE");
                }
            }
        }

    }
}