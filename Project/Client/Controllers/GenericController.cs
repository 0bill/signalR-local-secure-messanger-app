using System;
using System.Windows.Forms;

namespace Client.Controllers
{
    public abstract class GenericController<T>
    {
        protected T View;


        protected GenericController(T view)
        {
            this.View = view;
            LoadView();
        }

        public T GetView()
        {
            return View;
        }
        
        private void LoadView()
        {
            var view = this.View as Form;
            if (view == null) return;
            view.Show();
            view.Closed += View_Closed;
        }

        private protected abstract void View_Closed(object sender, EventArgs e);
    }
}
