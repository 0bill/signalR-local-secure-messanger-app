using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Presenter.Helpers
{
    public class ServerConnection : IServerConnection
    {
        private const string HttpURL = "http://localhost:8080/chat";
        private HubConnection ServerChatConnection { get; set; }
        private IHubProxy ServerChat { get; set; }

        public ServerConnection()
        {

            ServerChatConnection = new HubConnection(HttpURL);
            ServerChat = ServerChatConnection.CreateHubProxy("ChatHub");
            ConnectAsync();
            Console.WriteLine("Server conn alive");
            


        }

        private async void ConnectAsync()
        {
            try
            {
                await ServerChatConnection.Start();
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Not connected");
            }
        }

      

    }

    public interface IServerConnection
    {

    }


}
