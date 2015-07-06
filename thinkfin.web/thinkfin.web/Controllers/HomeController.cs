using System.Web.Mvc;
using Castle.Core.Logging;


namespace thinkfin.web.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger = NullLogger.Instance;

        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        [Authorize]
        public ActionResult Index()
        {
            _logger.Debug("Index");
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}