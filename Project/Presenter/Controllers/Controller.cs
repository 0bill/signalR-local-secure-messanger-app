namespace Client.Controllers
{
    public abstract class Controller<T> 
    {
        private T _view;


        protected Controller(T view)
        {
            this._view = view;
        }

        public T GetView()
        {
            return _view;
        }
    }
}
