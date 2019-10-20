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
        void LoadMessages();
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
            
            Console.WriteLine("Message" + Id);
            
            _container = container;
            _container.Resolve<IHomeController>();
            
            EventHelper.GlobalEvent += Write;
            EventHelper.GlobalUserLoggedOff += Close;
        }

        private void Close(object sender, EventArgs e)
        {
            View.CloseView();
            Dispose();
        }

        private void Write(object sender, EventArgs e)
        {
        }

        ~MessageController() => Console.WriteLine("Destroyed" + Id);

        private protected override void View_Closed(object sender, EventArgs e)
        {
            Dispose();
        }

        public override void Dispose()
        {
            Console.WriteLine(this.GetHashCode());
            _container.Resolve<ObjectContainer>().DisposeObject(View);
            _container.Resolve<ObjectContainer>().DisposeObject(this);
            EventHelper.GlobalEvent -= Write;
            EventHelper.GlobalUserLoggedOff -= Close;
            GC.Collect();
            base.Dispose();
        }
       

        public string TalksWithUser()
        {
            return _TalksWithUser;
        }

        public void LoadMessages()
        {
            throw new NotImplementedException();
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