using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MYOB.Taxation.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TaxationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}