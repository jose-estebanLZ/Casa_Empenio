using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CasaEmpeño
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            var errorDetails = exception.Message;

            string jsonResponse = JsonConvert.SerializeObject(errorDetails);

            Response.Clear();
            Response.StatusCode = 500;
            Response.ContentType = "application/json";
            Response.Write(jsonResponse);

            Server.ClearError();
        }
    }
}
