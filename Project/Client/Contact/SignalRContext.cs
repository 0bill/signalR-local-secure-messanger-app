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
        void SetConnection(Token token);
        void Dispose();
        void SendMessage(Domain.Message message);
        void MessageReceived(Message msg);
    }

    /// <summary>
    /// Class responsible for establish connection with SignalR server and handle all request between them.
    /// </summary>
    public class SignalRContext : ISignalRContext
    {
        private HubConnection _connection;
        private bool _dispose;

        /// <summary>
        /// Method creates and sets up http client
        /// </summary>
        /// <param name="token">Token representing the connection token</param>
        /// <returns></returns>
        public void SetConnection(Token token)
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
        
        /// <summary>
        /// Method invoked by server to pass new message
        /// </summary>
        /// <param name="msg"></param>
        private void OnIncomingMessage(Message msg)
        {
           EventHelper.RaiseOnIncomingMessage(this, new SendMessageArgs(msg));
           EventHelper.RaisePlayIncomingSound(this, new SendMessageArgs(msg));
           
        }

        /// <summary>
        /// Method notifies the server when a message is received
        /// </summary>
        /// <param name="msg"></param>
        public void MessageReceived(Message msg)
        {
            _connection.InvokeAsync("ReceivedMessage", msg);

        }

        /// <summary>
        /// Method responsible to validate certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            // TODO: Custom SSL certificate validation
            return true;
        }

        /// <summary>
        /// Method dispose and close connection
        /// </summary>
        public void Dispose()
        {
            _dispose = true;
            _connection.StopAsync();
            _connection.DisposeAsync();
        }

        /// <summary>
        /// Method send message to the server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(Domain.Message message)
        {
            _connection.InvokeAsync("Send", message);
        }
    }
}