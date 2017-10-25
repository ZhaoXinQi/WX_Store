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
        public IShowNewsService ShowNewsService { get; set; }//滚动新闻属性  依赖注入
        public IProService ProService { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            //查询banner
            var GetBanner = BannerService.GetEntities(x => true);
            ViewBag.Banner = GetBanner.ToList();
            //查询滚动新闻
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
        /// <summary>
        /// ShowNews内容页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult News(int id)//利用路由规则
        {
            //查询处点击的新闻的信息
            var GetShowNews = ShowNewsService.GetEntity(x => x.id == id);
            //赋值
            ViewBag.ShowNews_Title = GetShowNews.Title;
            ViewBag.ShowNews_ConTent = GetShowNews.Content;
            ViewBag.ShowNews_Time = GetShowNews.CreateTime;
            return View();
        }
        //查询热销信息
        public ActionResult HotSell()
        {
            //查询热销商品信息 WxShop_Model Fish_Model
            var GetPro = ProService.GetEntities(x => x.IsHot = true).Take(3);
            ViewBag.Pro = GetPro.ToList();
            return PartialView();
        }
        //查询推荐信息
        public ActionResult tuijian()
        {
            //查询推荐商品信息
            var GetPro = ProService.GetEntities(x =>true).OrderByDescending(x=>x.IsHot).Take(1);
            ViewBag.Pro = GetPro.ToList();
            return PartialView();
        }
    }
}