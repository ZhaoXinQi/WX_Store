using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace WX_Store.Controllers
{
    public class OrderController : Controller
    {
        public IShopCartService ShopCartService { get; set; }
        public IAddressService addressService { get; set; }
        public IProService proService { get; set; }

        // GET: Order
        public ActionResult Index()
        {
            string[] id = Request["id"].Split(',');//
            foreach (var item in id)
            {
                var shopOrder = ShopCartService.GetEntities(x => x.Cid == item);
            }
            ViewBag.id = id;
            ViewBag.pro = proService;
            ViewBag.shopcartService = ShopCartService;
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;//获取用户的信息
            string cid = userInfo.openid;//获取用户的openid
            var address = addressService.GetEntity(x => x.IsDefault == true&&x.cid==cid);//查找出关于用户的默认收货底座
            ViewBag.name = address.name;//把收货人传到前台
            ViewBag.address = address.address1;//把收货地址传到前台
            return View();
        }
        public ActionResult orderPay()
        {
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;//获取用户的信息
            string cid = userInfo.openid;//获取用户的openid
             
            return View();
        }
        public ActionResult JoinOrder()
        {

            //addressService.ExecuteCommand()
            return View();
        }
    }
}