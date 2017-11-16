using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WX_Store.Controllers
{
    public class OAuthController : Controller
    {
        //appID已经在配置里面填写,所以这里只需要里面配置里面appsettings的索引就能得到,这个在GetAuthorizeUrl()里面要用
        public static readonly string appID = ConfigurationManager.AppSettings["appID"];
        public static readonly string appsecret = ConfigurationManager.AppSettings["appsecret"];
        public static readonly string Domin = "http://zhao.zhaoxinqi.xin";
        // GET: OAuth
        public ActionResult Index(string returnUrl)
        {
            //构造带有域名的回调函数$标识变量占位符
            var redirect_uri = $"{Domin}{Url.Action("CallBack", new { returnUrl })}";
            //state 可以由开发者自己定义
            string state = "wx" + DateTime.Now.Millisecond;
            Session["state"] = state;//一旦比较之后就需要进行清空  ==null
            string redirect = OAuthApi.GetAuthorizeUrl(appID, redirect_uri, state, Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
            return Redirect(redirect);//该处的地址是内置好的,只需要跳转就行了
        }
        //写回调函数
        public ActionResult CallBack(string code, string state, string returnUrl)
        {
            //判断验证码是不是正确 //将获取到的自定义秘钥state与保存的session["state"]自定义秘钥比较验证
            if (Session["state"]?.ToString() != state)
            {
                Session["state"] = null;
                return Content("请从正确渠道进入网站");
            }
            Session["state"] = null;
            //判断code
            if (string.IsNullOrEmpty(code))
            {
                //如果没有code返回授权界面
                return RedirectToAction("index");
            }
            var accessToken = OAuthApi.GetAccessToken(appID, appsecret, code);//获取token, 这里返回的是一个对象
            if (accessToken.errcode != ReturnCode.请求成功)//returncode 需要引用命名空间
            {
                //需要重新定位到授权页面
                return Content($"错误消息:{accessToken.errmsg}");
            }
            Session["oauthAccessToken"] = accessToken;//保存起来供过滤器判断
            try
            {
                OAuthUserInfo userInfo = OAuthApi.GetUserInfo(accessToken.access_token,accessToken.openid);
                Session["userInfo"] = userInfo;
                return Redirect(returnUrl);
            }
            catch (Exception)
            {
                //如果没有获取到用户信息,则需要进入授权界面
                var redirect_uri = $"{Domin}{Url.Action("CallBack", new { returnUrl })}";
                //随机数,加强回调请求的安全,相当于验证码
                string state1 = "wx" + DateTime.Now.Millisecond;
                Session["state"] = state1;
                string rdeirect = OAuthApi.GetAuthorizeUrl(appID, redirect_uri, state1, Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
                return Redirect(rdeirect);
            }

        }
    }
}