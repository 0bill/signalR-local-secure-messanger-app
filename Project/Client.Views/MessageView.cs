using System.Windows.Forms;
using Client.Forms;

namespace Client.Views
{
    public interface IMessageView : IView
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