using System.Windows.Forms;

namespace Client.Views
{
    public interface IMessageView
    {
        void Activate();
    }
    public partial class MessageView : Form, IMessageView
    {
        public MessageView()
        {
            InitializeComponent();
        }
    }
}