using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter.Presenters;

namespace Presenter.Views
{
    public interface ITestView

    {
        
        void show();
        void chanetext(string test);
        void setPresenter(ITestPresenter p);
        int inst { get; }
    }
}
