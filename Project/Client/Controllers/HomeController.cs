using Domain;
using System;
using System.Windows.Forms;
using Client.Views;
using Unity;

namespace Client.Controllers
{
    public interface IHomeController
    {
        IForm GetMainView();
    }

    class HomeController : GenericController<IForm>, IHomeController
    {
        IUnityContainer container;


        
        public HomeController(IUnityContainer unityContainer, IForm view) : base(view)
        {
            var user = new User();
            Console.WriteLine("Home" + this.GetHashCode());
            Console.WriteLine("unityContainer" + unityContainer.GetHashCode());
            container = unityContainer;
          
            
            //this.View.button += Test;
            //this.View.dzwoni += new EventHandler(answer);
        }

        private void Test(object sender, EventArgs e)
        {
            container.Resolve<IMessageController>();
            container.Resolve<IMessageController>();
            container.Resolve<IMessageController>();
            container.Resolve<IMessageController>();

        }

        private void answer(object sender, EventArgs e)
        {
            runTest();
        }

        public IForm GetMainView()
        {
            return this.View;
        }

        public void runTest()
        {
            //ITestController tempTestView = container.Resolve<TestController>();

            //passing values to constructor
            /*
            ITestPresenter tempTestView = container.Resolve<TestPresenter>(new ResolverOverride[]
            {
                new ParameterOverride("cn", container)
                //new ParameterOverride("view", container.Resolve<ITestView>())
            });
            */

            //tempTestView.GetView().show();

            //opt 2


            //_testView.getSub().show();
        }
    }
}