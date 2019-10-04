using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter.Views;

namespace Presenter.Presenters
{
    public abstract class Presenter<T> 
    {
        private T _view;


        protected Presenter(T view)
        {
            this._view = view;
        }

        public T GetView()
        {
            return _view;
        }
    }
}
