using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WX_Store.Filters;
namespace WX_Store.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [OAuth]
        public ActionResult Index()
        {
            //获取用户信息
            var userInfo = Session["userInfo"];
            return View(userInfo);
        }
    }
}