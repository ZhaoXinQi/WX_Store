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
        public IProService ProService { get; set; }
        // GET: Sort
        public ActionResult sort()
        {
            var SortFirst= SortFirstService.GetEntities(x => true).ToList();
            ViewBag.SortFirst = SortFirst;
            return View();
        }
        public ActionResult ProductInfo()
        {
            string id = Request["id"];
            //if(id==null)
            //{

            //}
            //根据类别code查询处商品
            var pro = ProService.GetEntities(x => x.ProductSortCode == id);
            ViewBag.pro = pro.ToList();
            return PartialView();
        }
    }
}