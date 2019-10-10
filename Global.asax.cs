using MVCAngular.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCAngular
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

      

      AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.registerBundle(BundleTable.Bundles);
        }
    }
}
