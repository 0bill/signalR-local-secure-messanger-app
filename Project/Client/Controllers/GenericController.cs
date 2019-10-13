namespace Client.Controllers
{
    public abstract class GenericController<T>
    {
        private T _view;


        protected GenericController(T view)
        {
            this._view = view;
        }

        public T GetView()
        {
            return _view;
        }
    }
}
