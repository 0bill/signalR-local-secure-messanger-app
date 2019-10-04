using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter.Views;

namespace Presenter.Presenters
{
    public interface IHomePresenter
    {
        IHomeView GetMainView();

    }
}
