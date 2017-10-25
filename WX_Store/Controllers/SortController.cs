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
        public IProService ProService { get; set; }
        // GET: Sort
        //查询一级菜单
        public ActionResult sort()
        {
            var SortFirst= SortFirstService.GetEntities(x => true).ToList();
            ViewBag.SortFirst = SortFirst;
            Session["Code"] = SortFirst;//把查询到的保存起来,默认二级菜单用
            return View();
        }
        //二级菜单
        public ActionResult ProductInfo()
        {
            string id = Request["id"];
            //第一次进如分类页是空的,需要给他赋值
            if (id == null)
            {
                List<ProductSort> list = Session["Code"] as List<ProductSort>;//获取一级菜单信息
                ProductSort productSort = list.FirstOrDefault(x => true);//查找一级菜单第一条信息
                id = productSort.Code;
            }
            //根据类别code查询处商品
            var pro = SortSecondService.GetEntities(x => x.FirstCode == id);
            ViewBag.pro = pro.ToList();
            return PartialView();
        }
        public ActionResult ProductAll(string id)
        {
            string code = id;//  Request["id"];
            var product = ProService.GetEntities(x => x.ProductSortCode == code);
            ViewBag.Pro = product.ToList();
            return View();
        }
    }
}