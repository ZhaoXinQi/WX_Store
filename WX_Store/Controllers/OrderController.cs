using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System.Data.SqlClient;

namespace WX_Store.Controllers
{
    public class OrderController : Controller
    {
        public IShopCartService ShopCartService { get; set; }
        public IAddressService addressService { get; set; }
        public IProService proService { get; set; }
		public IOrderFathService orderFathService { get; set; }

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
        public ActionResult JoinOrder(string remark,string youfei,string pay)
        {
			OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;//获取用户的信息
			string cid = userInfo.openid;//获取用户的openid
			SqlParameter Uid = new SqlParameter("@user_id", cid);
			SqlParameter totalPrice = new SqlParameter("@total_Price", pay);
			SqlParameter expressPrice = new SqlParameter("@expressPrice", youfei);
			SqlParameter Remark = new SqlParameter("@ReMark", remark);
			SqlParameter msg = new SqlParameter() {
				 ParameterName= "@msg",
				  SqlDbType= System.Data.SqlDbType.NVarChar,
				  Size=50,
				   Direction= System.Data.ParameterDirection.Output
			};
			//这里需要注意：利用这个方法的时候里面的@字段，需要与存储过程里面的字段保持一致，不然会出现：“参数只能是数据库参数和值的错误”
			/* 如果存储过程里面有输出参数，同样需要参数化，只是参数化的方法不一样，需要指明参数名称、参数类型、类型的大小、描述：这个描述说明这个是一个输出的参数*/
			addressService.ExecuteCommand("exec proInsertOrder @user_id,@total_Price,@expressPrice,@ReMark,@msg output", Uid,totalPrice,expressPrice, Remark, msg);
			return Content(msg.Value.ToString());
        }
		public ActionResult OrderPay(string id)
		{
			ViewBag.num = id;
			var order = orderFathService.GetEntity(x => x.ChirldOrderId == new Guid(id));
			ViewBag.money = order.TotalPrice;
			return View();
		}
    }
}