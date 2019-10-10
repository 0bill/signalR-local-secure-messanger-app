using Client.Controllers;
namespace Client.Views
{
    public interface ITestView

    {
        
        void show();
        void chanetext(string test);
        void setPresenter(ITestController p);
        int inst { get; }
    }
}
