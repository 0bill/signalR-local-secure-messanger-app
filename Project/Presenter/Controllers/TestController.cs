using System;
using Client.Views;
using Unity;

namespace Client.Controllers
{
    public class TestController : Controller<ITestView>, ITestController
    {
        ITestView test;
        public int inst = new Random().Next(100000);

        public int getinstance => inst;
        //ITestView itest,
        public TestController(IUnityContainer unityContainer, ITestView view) : base(view)
        {
            Console.WriteLine("unityContainer" + unityContainer.GetHashCode());
            Console.WriteLine("Home" + unityContainer.Resolve<HomeController>().GetHashCode());
            Console.WriteLine("TestPresenter created" + inst.ToString());

            test = view;
            
            Console.WriteLine("TestPresenter created WIEW" + view.inst.ToString());

            test.chanetext("");
            view.setPresenter(this);
        }




        ~TestController()
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
