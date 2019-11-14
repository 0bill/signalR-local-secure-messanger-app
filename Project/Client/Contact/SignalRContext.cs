using System;
using System.Media;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Helpers;
using Client.Views.Events;
using Domain;
using Message = Domain.Message;

namespace Client.Contact
{
    interface ISignalRContext
    {
        void EstablishConnection(Token token);
        void Dispose();
        void SendMessage(Domain.Message message);
        void MessageReceived(Message msg);
    }

    public class SignalRContext : ISignalRContext
    {
        private HubConnection _connection;
        private bool _dispose;

        public void EstablishConnection(Token token)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chat", options =>
                {
                    options.WebSocketConfiguration = (config) =>
                    {
                        config.RemoteCertificateValidationCallback = ValidateCertificate;
                    };
                    options.HttpMessageHandlerFactory = (handler) =>
                    {
                        if (handler is HttpClientHandler clientHandler)
                        {
                            clientHandler.ServerCertificateCustomValidationCallback = ValidateCertificate;
                        }

                        return handler;
                    };
                    
                    options.Headers["Authorization"] = "Bearer " + token.JwtToken;
                })
                
                .Build();

            _connection.On<Domain.Message>("IncomingMessage", (msg) => OnIncomingMessage(msg));
            _connection.On<int>("Abort", (i) => EventHelper.RaiseGlobalUserLoggedOff(this,null) );
            
            try
            {
                _connection.StartAsync();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Unable to connect to server: Start server before connecting clients.");
 
            }

            
            _connection.Closed += error =>
            {
                Console.WriteLine("Closed");
                //todo: co ma byc po zamknieciu polaczenia
                if (!_dispose) 
                    EventHelper.RaiseGlobalUserLoggedOff(this,null);
                return Task.CompletedTask;
            };
            
            
        }

   

        private void OnIncomingMessage(Message msg)
        {
           EventHelper.RaiseOnIncomingMessage(this, new SendMessageArgs(msg));
           EventHelper.RaisePlayIncomingSound(this, new SendMessageArgs(msg));
           
        }


        public void MessageReceived(Message msg)
        {
            _connection.InvokeAsync("ReceivedMessage", msg);

        }

        private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            // TODO: Custom SSL certificate validation
            return true;
        }

        public void Dispose()
        {
            _dispose = true;
            _connection.StopAsync();
            _connection.DisposeAsync();
        }

        public void SendMessage(Domain.Message message)
        {
            _connection.InvokeAsync("Send", message);
        }
    }
}