using Presenter.Presenters;
using Presenter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter.Helpers;
using Unity;
using Unity.Lifetime;
   
namespace Presenter
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
                .RegisterType<IHomePresenter, HomePresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IServerConnection, ServerConnection>(new ContainerControlledLifetimeManager())
                .RegisterType<IHomeView, HomeView>(new ContainerControlledLifetimeManager())
                .RegisterType<ITestPresenter, TestPresenter>(new ContainerControlledLifetimeManager())
                //new TransientLifetimeManager()
                .RegisterType<ITestView, TestView>(new TransientLifetimeManager()) ;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Init one instance of home presenter
            unityContainer.RegisterInstance(unityContainer.Resolve<HomePresenter>());
            unityContainer.RegisterInstance(unityContainer.Resolve<ServerConnection>());

            

            

            Application.Run((Form)unityContainer.Resolve<HomePresenter>().GetMainView());
        }
    }
}
