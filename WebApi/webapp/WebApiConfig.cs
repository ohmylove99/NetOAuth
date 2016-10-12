using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json.Serialization;

namespace WebApi.webapp
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "AllCustomers",
            //    routeTemplate: "customers",
            //    defaults: new { controller = "Customers", action = "Get" }
            //    );
            config.MapHttpAttributeRoutes();

            config.EnsureInitialized();

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            RegisterFormatters(config.Formatters);
        }

        private static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.Add(new JQueryMvcFormUrlEncodedFormatter());
            formatters.Add(new XmlMediaTypeFormatter());

            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-www-form-urlencoded"));

            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.XmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            formatters.XmlFormatter.UseXmlSerializer = true;
            formatters.XmlFormatter.Indent = true;
        }
    }
}