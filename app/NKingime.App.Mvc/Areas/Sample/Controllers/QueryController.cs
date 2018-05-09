using System;
using System.Web.Mvc;
using NKingime.App.Entity;
using NKingime.App.Repository;
using NKingime.Utility.Extensions;


namespace NKingime.App.Mvc.Areas.Sample.Controllers
{
    public class QueryController : Controller
    {
        public IUserRepository UserRepository { get; set; }

        public ActionResult ListModel(int? pageSize, int? pageIndex)
        {
            var pagedResult = UserRepository.PagedList(pageSize.GetUnderlyingValue(), pageIndex.GetUnderlyingValue());
            return View(pagedResult);
        }

        public ActionResult ListViewBag(int? pageSize, int? pageIndex)
        {
            var pagedResult = UserRepository.PagedList(pageSize.GetUnderlyingValue(), pageIndex.GetUnderlyingValue());
            ViewBag.PagedResult = pagedResult;
            return View();
        }

        public ActionResult Create(User user)
        {
            if (user.Id == 0)
            {
                user = new Entity.User()
                {
                    Username = "test001",
                    Birthday = DateTime.Now.AddYears(-22),
                };
                user.Email = user.Username + "@163.com";
                user.Mobile = "13698745638";
            }
            UserRepository.Save(user);
            return RedirectToAction("Index");
        }
    }
}