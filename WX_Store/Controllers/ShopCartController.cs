﻿using System;
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
        public IProService proService { get; set; }
        public ISpecificationService specificationService { get; set; }
        // GET: ShopCart
        public ActionResult ShopCart()
        {
            //获取购物车信息
            string cid = Session["cid"].ToString();
            var shoppongCart = ShopCartService.GetEntities(x => x.Cid == cid);
            ViewBag.shopCart = shoppongCart.ToList();
            //把商品的信息传入前台供查询
            var pro = proService.GetEntity(x => x.Code == "E00100010001");
            ViewBag.pro1 = pro.Name;
            ViewBag.pro = proService;
            //把规格的信息传入前台
            ViewBag.Speci = specificationService;
            return View();
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