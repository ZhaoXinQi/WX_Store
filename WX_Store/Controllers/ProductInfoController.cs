using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
namespace WX_Store.Controllers
{
    public class ProductInfoController : Controller
    {
        public IProService ProService { get; set; }
        // GET: ProductInfo
        public ActionResult ProductInfo()
        {
            //查询出商品信息
            var code = Request["id"];
            var pro = ProService.GetEntity(x => x.Code == code);
            ViewBag.name = pro.Name;
            ViewBag.describe = pro.Describe;//描述
            return View();
        }
    }
}