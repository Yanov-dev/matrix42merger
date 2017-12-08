using System.Web.Http;
using Matrix42Merger.App_Start;

namespace Matrix42Merger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            MapperConfig.Register();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}