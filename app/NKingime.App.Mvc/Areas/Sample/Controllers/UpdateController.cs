using System;
using System.Web.Mvc;
using NKingime.App.Entity;
using NKingime.Core.Option;
using NKingime.App.IService;
using NKingime.Utility.Extensions;
using NKingime.App.EntityDto;

namespace NKingime.App.Mvc.Areas.Sample.Controllers
{
    /// <summary>
    /// 更新控制器
    /// </summary>
    public class UpdateController : Controller
    {
        /// <summary>
        /// 获取或设置 用户信息数据实体服务。
        /// </summary>
        public IUserService UserService { get; set; }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(long? uid)
        {
            var entity = UserService.GetByKey(uid.GetValue());
            if (entity == null)
            {
                ViewBag.Message = "未找到记录。";
                return View("Error");
            }
            return View(entity);
        }

        /// <summary>
        /// 删除。
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ActionResult Delete(long? uid)
        {
            var operateResult = UserService.DeleteByKeyWithCheckout(uid.GetValue());
            string message = "删除失败，";
            switch (operateResult.Result)
            {
                case DeleteResultOption.ArgumentError:
                    message += "参数错误。";
                    break;
                case DeleteResultOption.NotFound:
                    message += "未找到记录。";
                    break;
                case DeleteResultOption.Constraint:
                    message += "受限制。";
                    break;
                case DeleteResultOption.Success:
                    return RedirectToAction("ListModel", "Query");
            }
            ViewBag.Message = message;
            return View("Error");
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(UserSaveDto userDto)
        {
            var operateResult = UserService.UpdateWithCheckout(userDto);
            string message = "更新失败，";
            switch (operateResult.Result)
            {
                case UpdateResultOption.ArgumentError:
                    message += "参数错误。";
                    break;
                case UpdateResultOption.NotFound:
                    message += "未找到记录。";
                    break;
                case UpdateResultOption.Constraint:
                    message += "受限制。";
                    break;
                case UpdateResultOption.Success:
                    return RedirectToAction("ListModel", "Query");
            }
            ViewBag.Message = message;
            return View("Error");
        }
    }
}