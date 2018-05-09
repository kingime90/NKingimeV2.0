using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKingime.App.Mvc.Areas.Sample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Sample/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}