using System;
using System.Web.Mvc;
using PagedList;
using NKingime.App.Entity;
using NKingime.Utility.Extensions;
using NKingime.App.IService;

namespace NKingime.App.Mvc.Areas.Sample.Controllers
{
    public class QueryController : Controller
    {
        public IUserService UserService { get; set; }

        public ActionResult ListModel(int? pageSize, int? page)
        {
            //var pagedResult = UserRepository.PagedList(pageSize.GetValue(), page.GetValue());
            //var pagedLis = new StaticPagedList<User>(pagedResult.ResultList, pagedResult.PageIndex, pagedResult.PageSize, pagedResult.TotalCount);
            //return View(pagedLis);
            return View();
        }

        public ActionResult ListViewBag(int? pageSize, int? pageIndex)
        {
            //var pagedResult = UserRepository.PagedList(pageSize.GetValue(), pageIndex.GetValue());
            //ViewBag.PagedResult = pagedResult;
            return View();
        }

        public ActionResult Create(User user)
        {
            //if (user.Id == 0)
            //{
            //    user = new Entity.User()
            //    {
            //        Username = "test001",
            //        Birthday = DateTime.Now.AddYears(-22),
            //    };
            //    user.Email = user.Username + "@163.com";
            //    user.Mobile = "13698745638";
            //}
            //UserRepository.Save(user);
            return RedirectToAction("Index");
        }
    }
}