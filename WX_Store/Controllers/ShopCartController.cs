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
        public IShopCartService ShopCartService { get; set; }
        // GET: ShopCart
        public ActionResult ShopCart()
        {
            return View();
        }
        public ActionResult InsertShopCart()
        {
            string id = Request["id"];
            string price = Request["price"];
            //  string cid = Session["cid"].ToString();
            Guid g = System.Guid.NewGuid();
            
            ShoppongCart shoppongCart = new ShoppongCart
            {
                
                Id = g,
                Cid = "oczTIwrQsLEa6Ik_TZr4ALu1iZCM",
                Pcode = id,
                Price = Convert.ToDecimal(price),
                Totale = Convert.ToDecimal(price),
                CreateTime = DateTime.Now
            };
           if(ShopCartService.Add(shoppongCart))
            {
                return Content("完成添加");
            }
            else
            {
                return Content("未完成添加");
            }
        }
    }
}