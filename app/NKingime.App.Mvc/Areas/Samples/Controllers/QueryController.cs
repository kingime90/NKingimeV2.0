using NKingime.App.Repository;
using NKingime.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKingime.App.Mvc.Areas.Samples.Controllers
{
    public class QueryController : Controller
    {
        public IUserRepository UserRepository { get; set; }

        public ActionResult Index(int? pageSize,int? pageIndex)
        {
            var pagedList = UserRepository.PagedList(pageSize.GetOrDefault(0).Value, pageIndex.GetOrDefault(0).Value);
            return View(pagedList);
        }
    }
}