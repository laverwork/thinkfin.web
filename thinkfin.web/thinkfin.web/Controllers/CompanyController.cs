using System.Web.Mvc;

namespace thinkfin.web.Controllers
{
    public class CompanyController : Controller
    {
        [Authorize]
        public ActionResult Companies()
        {
            return View();
        }

        [Authorize]
        public ActionResult CompanyDetail()
        {
            return View();
        }
    }
}