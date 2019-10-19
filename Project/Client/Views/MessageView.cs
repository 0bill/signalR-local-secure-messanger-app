using System.Windows.Forms;

namespace Client.Views
{
    public interface IMessageView : IView
    {
        
    }
    public partial class MessageView : Form, IMessageView
    {
        public MessageView()
        {
            InitializeComponent();
        }
        
        
    }
}