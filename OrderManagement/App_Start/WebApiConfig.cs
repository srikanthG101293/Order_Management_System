using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OrderManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "AddProduct",
            //    routeTemplate: "api/{controller}/{action}/userID={userID}" +
            //    "/ProductName={ProductName}/Weight={Weight}/Height={Height}/ImageName={ImageName}/SKU={SKU}/Barcode={Barcode}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
