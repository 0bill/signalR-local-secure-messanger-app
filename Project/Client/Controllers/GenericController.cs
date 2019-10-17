namespace Client.Controllers
{
    public abstract class GenericController<T>
    {
        protected T View;


        protected GenericController(T view)
        {
            this.View = view;
        }

        public T GetView()
        {
            return View;
        }
    }
}
