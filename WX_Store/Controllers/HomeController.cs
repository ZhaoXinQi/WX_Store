using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using IBaseService;
namespace WX_Store.Controllers
{
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }//这里需要用public  依赖注入
        // GET: Home
        public ActionResult Index()
        {
            var GetBanner = BannerService.GetEntities(x => true);
            ViewBag.Banner = GetBanner.ToList();
         //   WxShop_Model Fish_Model
            return View();
        }
        public ActionResult Seach()
        {
            return View();
        }
    }
}