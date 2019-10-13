using System;
using System.Windows.Forms;
using Client.Controllers;
using Client.Helpers;
using Client.Views;
using Presenter;
using Unity;
using Unity.Lifetime;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer unityContainer;

            unityContainer = new UnityContainer()
                .RegisterType<IHomeController, HomeController>(new ContainerControlledLifetimeManager())
                .RegisterType<IServerConnection, ServerConnection>(new ContainerControlledLifetimeManager())
                .RegisterType<IHomeView, HomeView>(new ContainerControlledLifetimeManager())
                .RegisterType<ITestController, TestController>(new ContainerControlledLifetimeManager())
                //new TransientLifetimeManager()
                .RegisterType<ITestView, TestView>(new TransientLifetimeManager()) ;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Init one instance of home presenter
            unityContainer.RegisterInstance(unityContainer.Resolve<HomeController>());
            unityContainer.RegisterInstance(unityContainer.Resolve<ServerConnection>());

            

            

            Application.Run((Form)unityContainer.Resolve<HomeController>().GetMainView());
        }
    }
}
