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
        private IBannerService bannerService { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            var GetBanner = bannerService.GetEntities(x => true);
            ViewBag.Banner = GetBanner.ToList();
            return View();
        }
        public ActionResult Seach()
        {
            return View();
        }
    }
}