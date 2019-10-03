using System;
using Presenter.Views;

namespace Presenter
{
    public interface IHomeView : IView
    {
        event EventHandler dzwoni;
    }
}