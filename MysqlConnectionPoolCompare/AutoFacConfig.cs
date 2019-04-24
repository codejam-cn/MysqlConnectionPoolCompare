using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

/*
 *https://www.cnblogs.com/netcore2/p/7419045.html
 * 依赖注入三种生命周期管理模式
 * namespace Microsoft.Extensions.DependencyInjection
 * {
 *     public enum ServiceLifetime
 *     {
 *         Singleton,
 *         Scoped,
 *         Transient
 *     }
 * }
 *
 * 从源码可以看出，依赖注入框架（DI）支持三种生命周期管理模式
 * 
 * Singleton
 *          单例模式，服务在第一次请求时被创建，其后的每次请求都沿用这个已创建的服务。我们不用再自己写单例了。
 * 
 * Scoped
 * 　　   作用域模式，服务在每次请求时被创建，整个请求过程中都贯穿使用这个创建的服务。比如Web页面的一次请求。
 * 
 * Transient
 * 　　　瞬态模式，服务在每次请求时被创建，它最好被用于轻量级无状态服务。
 *
 *
 */
namespace MysqlConnectionPoolCompare
{
    /*
     *
     *
     */
    public class AutoFacConfig
    {
        public static IContainer container { get; set; }

        public AutoFacConfig()
        {

        }

        public static void Register()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<HtmlParser>()

            container = builder.Build();
            
        }
    }
}
