using Microsoft.AspNetCore.Mvc;

namespace MYOB.Taxation.Web.Controllers
{
    public class AboutController : TaxationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}