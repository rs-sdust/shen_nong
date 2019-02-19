using shen_nong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace shen_nong
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "{controller}/{action}",
            //    defaults: new { controller = "Home" }
            //);
        }
    }
}
