using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace MYOB.Taxation.Web.Controllers
{
    public abstract class TaxationControllerBase: AbpController
    {
        protected TaxationControllerBase()
        {
            LocalizationSourceName = TaxationConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}