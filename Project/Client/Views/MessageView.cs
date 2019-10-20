using System.Windows.Forms;
using Client.Forms;

namespace Client.Views
{
    public interface IMessageView : IView
    {
        void Activate();
        void CloseView();
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
    }
}