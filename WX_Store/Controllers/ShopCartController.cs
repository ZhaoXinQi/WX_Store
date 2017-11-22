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
    public class ShopCartController : Controller
    {
        public IShopCartService ShopCartService { get; set; }//购物车
        public IProService proService { get; set; }//商品
        public ISpecificationService specificationService { get; set; }//规格
        public IFavariteService favariteService { get; set; }//收藏
        // GET: ShopCart
        public ActionResult ShopCart()
        {
            //获取购物车信息
            string cid = Session["cid"].ToString();
            var shoppongCart = ShopCartService.GetEntities(x => x.Cid == cid);
            ViewBag.shopCart = shoppongCart.ToList();
            //把商品的信息传入前台供查询
           // var pro = proService.GetEntity(x => x.Code == "E00100010001");
          //  ViewBag.pro1 = pro.Name;
            ViewBag.pro = proService;
            //把规格的信息传入前台
            ViewBag.Speci = specificationService;
            return View();
        }
        public ActionResult Jia()
        {
            return Content("213");
        }
        /// <summary>
        /// 插入购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertShopCart()
        {
            string id = Request["id"];
            string price = Request["price"];
            string cid = Session["cid"].ToString();
            int num = Convert.ToInt32(Request["num"]);
            Guid g = System.Guid.NewGuid();
            //把传过来的商品信息和用户信息添加到数据库
            ShoppongCart shoppongCart = new ShoppongCart
            {

                Id = g,
                Cid = cid,
                Pcode = id,
                num = num,
                Price = Convert.ToDecimal(price),
                Totale = Convert.ToDecimal(price) * num,
				IsCheck=0,
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
        public ActionResult JoinLove()
        {
            string pcode = Request["pcode"];
            string price = Request["price"];
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;
            string cid= userInfo.openid;//获取用户的id
            Favarite favarite = new Favarite()//初始化一个收藏类
            {
                Pcode = pcode,
                Cid = cid,
                Price = Convert.ToDecimal(price),
                Createtime = DateTime.Now
            };
            var haveLove = favariteService.GetEntity(x => x.Pcode == pcode);//查找收藏类里面有没有该商品
            if (haveLove!=null)//如果存在则提示已经存在
            {
                return Content(" 已经存在");
            }
            else//如果不存在就添加
            {
                if (favariteService.Add(favarite))//如果添加成功，则提示
                {
                    return Content("加入成功");
                }
                else//添加不成功则提示失败
                {
                    return Content("加入失败,请重新尝试");
                }
            }
        }
		public ActionResult UpdateShopCart(string pcode)
		{
			string cid = Session["cid"].ToString();
			var shop = ShopCartService.GetEntity(x => x.Cid == cid && x.Pcode == pcode);
			shop.IsCheck = 1;
			bool a= ShopCartService.Modify(shop);

			return View();
		}
		public ActionResult UpdateShopCart1(string pcode)
		{
			string cid = Session["cid"].ToString();
			var shop1 = ShopCartService.GetEntity(x => x.Cid == cid && x.Pcode == pcode);
			shop1.IsCheck = 0;
			bool a = ShopCartService.Modify(shop1);

			return View();
		}
	}
}