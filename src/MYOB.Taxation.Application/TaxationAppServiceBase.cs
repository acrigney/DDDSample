using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using MYOB.Taxation.MultiTenancy;
using MYOB.Taxation.Users;
using Microsoft.AspNet.Identity;
using Abp.Runtime.Session;
using Abp.IdentityFramework;

namespace MYOB.Taxation
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TaxationAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected TaxationAppServiceBase()
        {
            LocalizationSourceName = TaxationConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}