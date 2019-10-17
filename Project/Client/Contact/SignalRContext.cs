using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Client.Contact
{
    interface ISignalRContext
    {
        void EstablishConnection();
    }

    public class SignalRContext : ISignalRContext
    {
        private HubConnection _connection;

        public void EstablishConnection()
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
                    options.Headers["token"] = "Bar";
                })
                .Build();
            
            _connection.Closed += Connection_Closed;
        }
        
        private Task Connection_Closed(Exception arg)
        {
            //Todo: implement disconnect
            Console.WriteLine("Connection_Closed");
            return null;
        }

        private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            // TODO: Custom SSL certificate validation
            return true;
        }
    }
}