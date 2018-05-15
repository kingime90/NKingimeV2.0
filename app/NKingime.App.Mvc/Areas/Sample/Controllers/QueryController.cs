using System;
using System.Web.Mvc;
using PagedList;
using NKingime.App.Entity;
using NKingime.App.IService;
using NKingime.Utility.Extensions;

namespace NKingime.App.Mvc.Areas.Sample.Controllers
{
    /// <summary>
    /// 查询控制器。
    /// </summary>
    public class QueryController : Controller
    {
        /// <summary>
        /// 获取或设置 用户信息数据实体服务。
        /// </summary>
        public IUserService UserService { get; set; }

        public ActionResult ListModel(int? pageSize, int? page)
        {
            var pagedResult = UserService.PagedList(pageSize.GetValue(), page.GetValue());
            var pagedLis = new StaticPagedList<User>(pagedResult.ResultList, pagedResult.PageIndex, pagedResult.PageSize, pagedResult.TotalCount);
            return View(pagedLis);
        }

        public ActionResult ListViewBag(int? pageSize, int? page)
        {
            var pagedResult = UserService.PagedList(pageSize.GetValue(), page.GetValue());
            ViewBag.PagedResult = pagedResult;
            return View();
        }
    }
}