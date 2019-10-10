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
        private const string HttpUrLforSingalR = "http://localhost:8080/chat";
        private const string HttpUrLforWebApi = "http://localhost:8080/api/login";
        private HubConnection ServerChatConnection { get; set; }
        private IHubProxy ServerChat { get; set; }

        public ServerConnection()
        {
            //ConnectAsync();
            WebApiConnect();
        }

        private void WebApiConnect()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage message = httpClient.GetAsync(HttpUrLforWebApi).Result;
 
            if (message.IsSuccessStatusCode)
            {
                var messaResult = message.Content.ReadAsStringAsync().Result;
                Console.WriteLine(messaResult);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private async void ConnectAsync()
        {
            ServerChatConnection = new HubConnection(HttpUrLforSingalR);
            ServerChat = ServerChatConnection.CreateHubProxy("ChatHub");

            try
            {
                await ServerChatConnection.Start();
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Not connected");
            }

            Console.WriteLine("Server conn alive");
        }
    }

    public interface IServerConnection
    {
    }
}