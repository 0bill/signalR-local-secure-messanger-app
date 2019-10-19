using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controllers;
using Client.Data;
using Client.Helpers;
using Client.Views;
using Unity;
using Unity.Lifetime;

namespace Client
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IUnityContainer unityContainer = new UnityContainer()
                .AddNewExtension<TrackInstantiatedObjectsExtension>()
                .RegisterType<IClientDataRuntime, ClientDataRuntime>(new ContainerControlledLifetimeManager())
                .RegisterType<IHomeController, HomeController>(new ContainerControlledLifetimeManager())
                .RegisterType<IHomePanelView, HomePanelView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMessageController, MessageController>(new TransientLifetimeManager())
                .RegisterType<IMessageView, MessageView>(new TransientLifetimeManager());

            unityContainer.RegisterInstance(unityContainer.Resolve<IHomeController>());
            unityContainer.RegisterInstance(unityContainer.Resolve<IClientDataRuntime>());

          
            Application.Run((Form)unityContainer.Resolve<IHomeController>().GetStartGetView());

        }
    }
}
