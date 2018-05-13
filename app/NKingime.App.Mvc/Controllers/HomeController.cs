using System.Web.Mvc;

namespace NKingime.App.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? pageSize, int? pageIndex)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}