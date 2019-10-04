using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace Server
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            Route.RegisterRoutes(httpConfig);
            app.UseCors(CorsOptions.AllowAll);
            app.Map("/chat", map =>
            {
                HubConfiguration hubConfig = new HubConfiguration();
                map.RunSignalR();
            });

            app.UseWebApi(httpConfig);


        }
    }
}
