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

        protected T GetView()
        {
            return View;
        }
        
        private void LoadView()
        {
            var view = this.View as Form;
            if (View == null) return;
            view.Show();
            view.Closed += View_Closed;
        }

        private protected abstract void View_Closed(object sender, EventArgs e);


        protected virtual void Dispose()
        {
            var view = this.View as Form;
            if (View == null) return;
            view.Closed -= View_Closed;
        }
    }

   
}
