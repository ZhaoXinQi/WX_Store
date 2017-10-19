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
        public IShowNewsService ShowNewsService { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            var GetBanner = BannerService.GetEntities(x => true);
            ViewBag.Banner = GetBanner.ToList();
            var GetShowNews = ShowNewsService.GetEntities(x => true);
            ViewBag.ShowNews = GetShowNews.ToList();
            return View();
        }
        /// <summary>
        /// 搜索的分部视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Seach()
        {
            return PartialView();
        }
        public ActionResult SeachHtml()
        {
            return View();
        }
    }
}