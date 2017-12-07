using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Matrix42Merger
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}