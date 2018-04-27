using NKingime.App.Repository;
using NKingime.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKingime.App.Mvc.Controllers
{
    public class HomeController : Controller
    {

        public IUserRepository UserRepository { get; set; }

        public ActionResult Index(int? pageSize, int? pageIndex)
        {
            var pagedList = UserRepository.PagedList(pageSize.GetOrDefault(0).Value, pageIndex.GetOrDefault(0).Value);
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