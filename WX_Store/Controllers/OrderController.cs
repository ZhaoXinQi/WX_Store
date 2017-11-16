using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
namespace WX_Store.Controllers
{
    public class OrderController : Controller
    {
        public IShopCartService ShopCartService { get; set; }
        public IProService proService { get; set; }
        // GET: Order
        public ActionResult Index()
        {
            string[] id = Request["id"].Split(',');
            foreach (var item in id)
            {
                var shopOrder = ShopCartService.GetEntities(x => x.Cid == item);
            }
            ViewBag.id = id;
            ViewBag.shopcartService = ShopCartService;
            ViewBag.pro = proService;
            return View();
        }
    }
}