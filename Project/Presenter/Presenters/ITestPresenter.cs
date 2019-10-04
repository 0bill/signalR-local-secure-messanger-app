using Presenter.Views;

namespace Presenter.Presenters
{
    public interface ITestPresenter
    {

        ITestView GetView();
        void poka();
        ITestView getSub();
    }
}