using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ConnectAsync();

        }

        private async void ConnectAsync()
        {
            var url = "https://localhost:5001/chat";
            HubConnection Connection = new HubConnection(url);
            IHubProxy hub = Connection.CreateHubProxy("ChatHub");

            try
            {
                await Connection.Start();
                Console.WriteLine("Connect");

            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Not connect");

            }
        }
    }
}
