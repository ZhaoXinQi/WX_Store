using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WX_Store.Filters
{
    public class OAuthAttribute:AuthorizeAttribute
    {
        /// <summary>
        /// 判断用户是否具备访问第三方网站的权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["oauthAccessToken"] == null)
            {
                //如果不满足则跳到授权界面
                //获取当前需要访问的页面url
                string returnUrl = filterContext.HttpContext.Request.RawUrl;
                //带参数地址进入授权界面
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new RedirectResult(url.Action("Index", "OAuth", new { returnUrl = returnUrl }));
            }
        }
    }
}