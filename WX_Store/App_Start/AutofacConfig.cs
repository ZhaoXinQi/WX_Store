using Autofac;//需要饮用自动工厂类
using Autofac.Integration.Mvc;//引用此类,注册工厂用
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;//需要饮用程序集类 assmbly使用
using System.Web.Mvc;

namespace WX_Store.App_Start
{
    public class AutofacConfig
    {
        public static void SautoDepence()
        {
            //先实例化一个构造器
            var builder = new ContainerBuilder();
            //注册使用方    后面需要使用 PropertiesAutowired()方法,把注册的编程使用方
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //通过程序集下面给定程序集的长格式名称加载程序集
            var iRepository = Assembly.Load("Fish_IRepository");
            var iService = Assembly.Load("IBaseService");
            var Repository = Assembly.Load("Fish_Repository");
            var Service = Assembly.Load("Fish_Service");
            //注册实现方    where后面是匹配后面的结尾是否为指定的字符串结尾
            builder.RegisterAssemblyTypes(iRepository, Repository).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(iService, Service).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            //创建容器
            var container = builder.Build();
            //依赖注入
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}