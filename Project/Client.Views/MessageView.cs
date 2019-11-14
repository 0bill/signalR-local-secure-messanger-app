using System;
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
        EventHandler OnMessageSend;
        public MessageView()
        {
            InitializeComponent();
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            OnMessageSend.Invoke(sender,e);
        }
    }
}