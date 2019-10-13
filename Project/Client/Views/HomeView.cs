using System;
using System.Net.Http;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace Client.Views
{
    public interface IHomeView : IView
    {
        event EventHandler dzwoni;
    }

    public partial class HomeView : Form, IHomeView
    {
        public HomeView()
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
            catch (HttpRequestException e )
            {
                Console.WriteLine("Not connect");
                Console.WriteLine(e.Message);

            }
        }


        public event EventHandler dzwoni;
    }
}
