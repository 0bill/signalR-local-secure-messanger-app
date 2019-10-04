using Presenter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Presenter.Presenters
{
    public class TestPresenter : Presenter<ITestView>, ITestPresenter
    {
        ITestView test;
        public int inst = new Random().Next(100000);

        public int getinstance => inst;
        //ITestView itest,
        public TestPresenter(IUnityContainer unityContainer, ITestView view) : base(view)
        {
            Console.WriteLine("unityContainer" + unityContainer.GetHashCode());
            Console.WriteLine("Home" + unityContainer.Resolve<HomePresenter>().GetHashCode());
            Console.WriteLine("TestPresenter created" + inst.ToString());

            test = view;
            
            Console.WriteLine("TestPresenter created WIEW" + view.inst.ToString());

            test.chanetext("");
            view.setPresenter(this);
        }




        ~TestPresenter()
        {
            Console.WriteLine("TestPresenter die"
            +inst.ToString());

        }


        public ITestView getSub()
        {
            return test;
        }

        public ITestView GetView()
        {
            return test;
        }

    
        public void poka()
        {
            test.show();
        }



      
      
    }
}
