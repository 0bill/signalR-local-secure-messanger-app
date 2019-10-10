using Client.Views;

namespace Client.Controllers
{
    public interface ITestController
    {

        ITestView GetView();
        void poka();
        ITestView getSub();
    }
}