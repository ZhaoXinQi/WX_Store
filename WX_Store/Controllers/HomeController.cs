using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxShop_Model;
using Fish_IRepository;
using IBaseService;
namespace WX_Store.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 以属性方式注入
        /// </summary>
        public IBannerService bannerService { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            var bannerResult = bannerService.GetEntities(x => true);
            ViewBag.banner = bannerResult.ToList();
            return View();
        }
        public ActionResult Seach()
        {
            return View();
        }
    }
}