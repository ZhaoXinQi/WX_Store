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
    }
}