using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter.Views;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace Presenter.Presenters
{
    class HomePresenter : Presenter<IHomeView>, IHomePresenter
    {



        IHomeView _homeView;
       // ITestPresenter _testView;
        IUnityContainer container;

        //, ITestPresenter x
        public HomePresenter(IUnityContainer unityContainer, IHomeView view) : base(view)
        {

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
           ITestPresenter tempTestView = container.Resolve<TestPresenter>();

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
