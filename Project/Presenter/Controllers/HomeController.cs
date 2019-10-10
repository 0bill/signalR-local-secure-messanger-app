using System;
using Client.Views;
using Domain;
using Unity;

namespace Client.Controllers
{
    class HomeController : Controller<IHomeView>, IHomeController
    {



        IHomeView _homeView;
       // ITestPresenter _testView;
        IUnityContainer container;

        //, ITestPresenter x
        public HomeController(IUnityContainer unityContainer, IHomeView view) : base(view)
        {
            var user = new User();
            Console.WriteLine("Home" + this.GetHashCode());
            Console.WriteLine("unityContainer" + unityContainer.GetHashCode());
            container = unityContainer;
            _homeView = view;

           // _testView = x;


            _homeView.dzwoni += new EventHandler(answer);
            
        }

        private void answer(object sender, EventArgs e)
        {
            //_testView.getSub().show();

             runTest();

        }
        /// <summary>
        /// return intatance of view
        /// </summary>
        /// <returns></returns>
        public IHomeView GetMainView()
        {
            return _homeView;
        }
        /// <summary>
        /// Get presenter inst and pick and show view
        /// </summary>
        public void runTest()
        {
            ITestController tempTestView = container.Resolve<TestController>();

            //passing values to constructor
            /*
            ITestPresenter tempTestView = container.Resolve<TestPresenter>(new ResolverOverride[]
            {
                new ParameterOverride("cn", container)
                //new ParameterOverride("view", container.Resolve<ITestView>())
            });
            */

            tempTestView.GetView().show();

            //opt 2


            //_testView.getSub().show();

        }
    }
}
