using System;
using System.Windows.Forms;
using Client.Helpers;
using Client.Views;
using Unity;

namespace Client.Controllers
{

    public interface IMessageController
    {
        string TalksWithUser();
        void Activate();
        void TalksWithUser(string talkWith);
    }
    public class MessageController : GenericController<IMessageView>, IMessageController
    {
        private int Id => this.GetHashCode();
        private IUnityContainer _container;
        private string _TalksWithUser;

        public MessageController(IUnityContainer container, IMessageView view) : base(view)
        {
            _container = container;
            Console.WriteLine("Message" + Id);
            EventHelper.GlobalEvent += Write;
            _container.Resolve<IHomeController>();
            EventHelper.GlobalUserLoggedOff += Close;
        }

        private void Close(object sender, EventArgs e)
        {
            View.CloseView();
        }

        private void Write(object sender, EventArgs e)
        {
            Console.WriteLine("ECHO");
        }

        ~MessageController() => Console.WriteLine("Destroyed" + Id);

        private protected override void View_Closed(object sender, EventArgs e)
        {
            _container.Resolve<ObjectContainer>().DisposeObject(this);
            _container.Resolve<ObjectContainer>().DisposeObject(sender);
            EventHelper.GlobalEvent -= Write;
            GC.Collect();
        }
        
        public string TalksWithUser()
        {
            Console.WriteLine(_TalksWithUser);
            return _TalksWithUser;
        }

        public void Activate()
        {
            this.View.Activate();
        }

        public void TalksWithUser(string talkWith)
        {
            _TalksWithUser = talkWith;
        }
    }
}