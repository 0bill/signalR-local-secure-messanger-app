using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Data;

namespace ServerApp.Hubs
{
    public class ChatHub : Hub
    {
        private IServiceProvider _serviceProvider;
        public ChatHub(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Lol()
        {
            if (Context.GetHttpContext().Request.IsHttps)
                Console.WriteLine("Got SSL");
            var x = (IServerRuntimeData)_serviceProvider.GetService(typeof(IServerRuntimeData));
            x.msg();
        }
        public override Task OnConnectedAsync()
        {
            

            Console.WriteLine(Context.ConnectionAborted);
            //Context.Abort();
            Console.WriteLine(Context.ConnectionAborted);

            Console.WriteLine("Connected " + Context.ConnectionId);

            var httpCtx = Context.GetHttpContext();
            Lol();
            var someHeaderValue = httpCtx.Request.Headers["Foo"].ToString();
            Console.WriteLine("HEADER " + someHeaderValue);

            string s = Context.GetHttpContext().Request.Headers["Foo"].ToString();

            


            return base.OnConnectedAsync();
           
        }

        

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("Disconnected " + Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }

}
