using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server
{
    class Route
    {
        public static void RegisterRoutes(HttpConfiguration routeConfiguration)
        {
            routeConfiguration.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new
                {
                    id = RouteParameter.Optional
                });
        }
    }
}
