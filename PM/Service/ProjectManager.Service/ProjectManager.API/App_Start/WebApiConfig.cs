using ProjectManager.API.Security;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using ProjectManager.API.App_Start;

namespace ProjectManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Replace(typeof(IExceptionLogger), new GlobalExceptionLogger());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
