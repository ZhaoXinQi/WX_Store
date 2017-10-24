using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
namespace WX_Store.Controllers
{
    public class SortController : Controller
    {
        //利用属性进行依赖注入
        public ISortFirstService SortFirstService { get; set; }
        public ISortSecondService SortSecondService { get; set; }
        // GET: Sort
        //查询一级菜单
        public ActionResult sort()
        {
            var SortFirst= SortFirstService.GetEntities(x => true).ToList();
            ViewBag.SortFirst = SortFirst;
            Session["Code"] = SortFirst;
            return View();
        }
        public ActionResult ProductInfo()
        {
            string id = Request["id"];
            if (id == null)
            {
                List<ProductSort> list = Session["Code"] as List<ProductSort>;
                ProductSort productSort = list.FirstOrDefault(x => true);
                id = productSort.Code;
            }
            //根据类别code查询处商品
            var pro = SortSecondService.GetEntities(x => x.Code == id);
            ViewBag.pro = pro.ToList();
            return PartialView();
        }
    }
}