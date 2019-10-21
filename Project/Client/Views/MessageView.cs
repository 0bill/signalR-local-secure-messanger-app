using System.Windows.Forms;
using Client.Forms;

namespace Client.Views
{
    public interface IMessageView : IView
    {
        void Activate();
        void CloseView();
        void LoadMessages();
    }
    public partial class MessageView : Form, IMessageView
    {
        public MessageView()
        {
            InitializeComponent();
        }
        
        public void CloseView()
        {
           this.Dispose();
        }

        public void LoadMessages()
        {
            throw new System.NotImplementedException();
        }
    }
}