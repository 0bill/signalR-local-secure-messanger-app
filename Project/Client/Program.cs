using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controllers;
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

            IUnityContainer unityContainer;

            unityContainer = new UnityContainer()
                .RegisterType<IHomeController, HomeController>(new ContainerControlledLifetimeManager())
                .RegisterType<IHomeView, HomeView>(new ContainerControlledLifetimeManager())
                ;

            unityContainer.RegisterInstance(unityContainer.Resolve<HomeController>());

          
            Application.Run((Form)unityContainer.Resolve<HomeController>().GetMainView());

        }
    }
}
