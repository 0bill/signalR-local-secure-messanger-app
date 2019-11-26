using System;
using System.Windows.Forms;

namespace Client.Controllers
{
    

    /// <summary>
    /// Generic controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericController<T> 
    {
        protected T View;

        protected GenericController(T view)
        {
            this.View = view;
            LoadView();
        }

        /// <summary>
        /// Returns controller view
        /// </summary>
        /// <returns></returns>
        protected T GetView()
        {
            return View;
        }
        
        /// <summary>
        /// Loads view
        /// </summary>
        private void LoadView()
        {
            var view = this.View as Form;
            if (View == null) return;
            view.Show();
            view.Closed += View_Closed;
        }

        
        private protected abstract void View_Closed(object sender, EventArgs e);


        /// <summary>
        /// Dispose controller
        /// </summary>
        protected virtual void Dispose()
        {
            var view = this.View as Form;
            if (View == null) return;
            view.Closed -= View_Closed;
        }
    }

   
}
