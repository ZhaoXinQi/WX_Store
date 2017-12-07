using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WX_Store.Filters;
using WxShop_Model;
using IBaseService;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
namespace WX_Store.Controllers
{
    public class UserController : Controller
    {
        public ICustomarService customarService { get; set; }
        public IAddressService addressService { get; set; }
		public IFavariteService favariteService { get; set; }
		public IProService proService { get; set; }
		public IOrderFathService orderFathService { get; set; }
		public IOrderChirldService orderChirldService { get; set; }
		public ISpecificationService specificationService { get; set; }
        // GET: User
        [OAuth]
        public ActionResult Index()
        {
            //获取用户信息
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;
            Session["cid"] = userInfo.openid;
            //判断数据库里面是否已经存在用户信息
            if (customarService.GetEntity(x => x.OpenId == userInfo.openid) == null)
            {
                Customar customar = new Customar();
                //Guid u = System.Guid.NewGuid();//用户的id因为是利用的NEWID()函数，所以需要用vs里面的guid与之对应
                //Session["cid"] = u;
                //customar.id = u;
                customar.Name = userInfo.nickname;
                customar.OpenId = userInfo.openid;
                customar.Phone = "0";
                customar.Address = userInfo.country + userInfo.province + userInfo.city;
                customar.CreateTime = DateTime.Now;
                customarService.Add(customar);
             
                return View(userInfo);
            }
            else
            {
                //添加无用的注释
                return View(userInfo);
            }
          
        }
        //用户地址
        public ActionResult Address()
        {
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;
            string cid = userInfo.openid;
            var address = addressService.GetEntities(x => x.cid == cid);
            ViewBag.add = address.ToList();
            return View(userInfo);
        }
        public ActionResult AddAddress()
        {
            return View();
        }
		/// <summary>
		/// 添加地址
		/// </summary>
		/// <returns></returns>
        public ActionResult AddressInsert()
        {
            OAuthUserInfo userInfo = Session["userInfo"] as OAuthUserInfo;
            string cid = userInfo.openid;
            var address = Request["address"];
            var name = Request["name"];
            var tel = Request["tel"];
            var check = Request["check"];//接收用户地址信息
            bool ischeck = false;
            if (check == "0")
            {
                ischeck = false;
            }
            else
            {
                ischeck = true;
            }///添加用户信息
            Address addressEntity = new Address()
            {
                cid = cid,
                address1 = address,
                tel = tel,
                name = name,
                IsDefault= ischeck
            };
            bool IsOk = addressService.Add(addressEntity);
          
            return Content(IsOk.ToString());
        }
		/// <summary>
		/// 收藏
		/// </summary>
		/// <returns></returns>
		public ActionResult Love()
		{
			var love = favariteService.GetEntities(x => x.Cid == Session["cid"].ToString());
			ViewBag.Love = love.ToList();
			ViewBag.pro = proService;
			return View();
		}
		/*************************我的订单未付款***********************************/
		public ActionResult MyOrder()
		{
			string cid = Session["cid"].ToString();
			var WeiFuKuan = orderFathService.GetEntities(x => x.state == "1").Where(x => x.Cid == cid);
			ViewBag.WeiFuKuan = WeiFuKuan.ToList();
			ViewBag.chirld = orderChirldService;
			ViewBag.pro = proService;
			ViewBag.spec = specificationService;
			return View();
		}
		/*************************我的订单待发货***********************************/
		public ActionResult DaiFaHuo()
		{
			string cid = Session["cid"].ToString();
			var DaiFaHuo1 = orderFathService.GetEntities(x => x.state == "2").Where(x => x.Cid == cid);
			ViewBag.daifahuo = DaiFaHuo1.ToList();
			ViewBag.chirld = orderChirldService;
			ViewBag.pro = proService;
			ViewBag.spec = specificationService;
			return View();
		}
    }
}