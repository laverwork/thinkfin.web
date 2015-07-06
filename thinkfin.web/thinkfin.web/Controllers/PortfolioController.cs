using System.Web.Mvc;

namespace thinkfin.web.Controllers
{
    public class PortfolioController : Controller
    {
        [Authorize]
        public ActionResult Portfolios()
        {
            return View();
        }
    }
}