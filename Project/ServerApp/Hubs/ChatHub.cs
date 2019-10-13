using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ServerApp.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected " + Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("Disconnected " + Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
