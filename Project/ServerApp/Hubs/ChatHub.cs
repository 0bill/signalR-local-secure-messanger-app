using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Data;

namespace ServerApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IServiceProvider _serviceProvider;
        public ChatHub(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void IsSSL()
        {
            if (Context.GetHttpContext().Request.IsHttps)
                Console.WriteLine("Got SSL");
            //get instance of GLOBAL DATA
            var x = (IServerDataRuntime)_serviceProvider.GetService(typeof(IServerDataRuntime));
            x.msg();
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected " + Context.ConnectionId);
            
            var token = Context.GetHttpContext().Request.Headers["token"].ToString();
            Console.WriteLine("HEADER " + token);
            //TODO: if token wrong then Context.Abort();
            //Console.WriteLine(Context.ConnectionAborted);

            IsSSL();
            return base.OnConnectedAsync();
           
        }

        

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("Disconnected " + Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }

}
