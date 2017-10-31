using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
using System.Reflection;

namespace WX_Store.Controllers
{
    public class ProductInfoController : Controller
    {
        public IProService ProService { get; set; }//定义商品属性,依赖注入
        public IStockService StockService { get; set; }//库存
        public ISpecificationService SpecificationService { get; set; }//规格
        public  IProductReviewService ProductReviewService { get; set; }//评价
        // GET: ProductInfo
        public ActionResult ProductInfo()
        {
            //查询出商品信息
            var code = Request["id"];
            var pro = ProService.GetEntity(x => x.Code == code);
            ViewBag.name = pro.Name;
            ViewBag.describe = pro.Describe;//描述
            ViewBag.price = pro.Price;
            ViewBag.img = pro.img;
            //遍历出来图片
            //for(int i=0;i < pro.img.Split(',').Length;i++)
            //{
            //    ViewBag.img[i] = pro.img.Split(',')[i];
            //}
            ViewBag.img1 = pro.img.Split(',')[0];
            ViewBag.img2 = pro.img.Split(',')[1];
            //  ViewBag.img3 = pro.img.Split(',')[2];
            //根据商品查询出来库存
            Stock stock = StockService.GetEntity(x => x.BillId == code);
            ViewBag.stock = stock.num;
            PropertyInfo[] pis = typeof(Stock).GetProperties();//反射  暂时用不到,用来遍历实体用
            //根据商品查询处商品规格
            int? id = pro.SpecificationId;
            Specification specification = SpecificationService.GetEntity(x => x.Id == id);
            var specification1 = SpecificationService.GetEntities(x => x.ProCode == pro.Code);
            ViewBag.Spcification = specification1;
            //产品描述
            ViewBag.describe = pro.Describe;
            //用户评价
            var proDuctReview = ProductReviewService.GetEntities(x => x.Pcode == pro.Code);
            ViewBag.ProReview = proDuctReview.ToList();
            return View();
        }
    }
}