using Presenter.Presenters;
using Presenter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                .RegisterType<IHomeView, HomeView>(new ContainerControlledLifetimeManager())
                .RegisterType<ITestPresenter, TestPresenter>(new ContainerControlledLifetimeManager())
                //new TransientLifetimeManager()
                .RegisterType<ITestView, TestView>(new TransientLifetimeManager()) ;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Init one instance of home presenter
            unityContainer.RegisterInstance(unityContainer.Resolve<HomePresenter>());

            

            

            Application.Run((Form)unityContainer.Resolve<HomePresenter>().GetMainView());
        }
    }
}
