using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
namespace WX_Store.Controllers
{
    public class ShopCartController : Controller
    {
        // GET: ShopCart
        public ActionResult ShopCart()
        {
            string id = Request["id"];

            return View();
        }
    }
}