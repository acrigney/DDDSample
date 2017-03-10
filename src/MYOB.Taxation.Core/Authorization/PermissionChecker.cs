using Abp.Authorization;
using MYOB.Taxation.Authorization.Roles;
using MYOB.Taxation.MultiTenancy;
using MYOB.Taxation.Users;

namespace MYOB.Taxation.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
