using System;
using System.Windows.Forms;
using Client.Views;

namespace Client.Controllers
{

    public interface IMessageController
    {
        void testController();
    }
    public class MessageController : GenericController<IMessageView>, IMessageController
    {
        private int Id => this.GetHashCode();
        public MessageController(IMessageView view) : base(view)
        {
            LoadView();
            Console.WriteLine("Message" + Id);
        }

        ~MessageController() => Console.WriteLine("Destroyed" + Id);
        public void testController()
        {
            Console.WriteLine("MESSEA" + Id);
        }


        public void LoadView()
        {
            var messageView = (Form)this.View;
            messageView.Show();
            messageView.Closed += View_Closed;
            
        }

        private void View_Closed(object sender, EventArgs e)
        {
            GC.Collect();
        }
        


    }
}