using Abp.AspNetCore.Mvc.Authorization;
using MYOB.Taxation.Authorization;
using MYOB.Taxation.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace MYOB.Taxation.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : TaxationControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}