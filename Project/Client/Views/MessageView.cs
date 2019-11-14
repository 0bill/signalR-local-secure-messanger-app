using System;
using System.Windows.Forms;
using Client.Forms;
using Client.Views.Controls;
using Client.Views.Events;

namespace Client.Views
{
    public interface IMessageView : IView
    {
        void Activate();
        void CloseView();
        void AddIncomingMessage(string message, DateTime dateTime);
        void AddSentMessage(string message, DateTime dateTime);
        void InitUser(string username);
        EventHandler OnMessageSend { get; set; }
    }

    public partial class MessageView : Form, IMessageView
    {
        private MessageControl _messageControl1;
        public EventHandler OnMessageSend { get; set; }
        public MessageView()
        {
            InitializeComponent();
            InitMessageControl();
        }

        private void InitMessageControl()
        {
            this._messageControl1 = new MessageControl();
            this.SuspendLayout();
            // 
            // messageControl1
            // 
            this._messageControl1.Anchor = AnchorStyles.Top |AnchorStyles.Bottom |AnchorStyles.Left |AnchorStyles.Right;
            this._messageControl1.AutoScroll = true;
            this._messageControl1.BackColor = System.Drawing.Color.White;
            this._messageControl1.BoxIndent = 150;
            this._messageControl1.LeftBoxColor = System.Drawing.Color.FromArgb(217,217,217);
            this._messageControl1.LeftBoxTextColor = System.Drawing.Color.FromArgb(52,52, 52);
            this._messageControl1.Location = new System.Drawing.Point(217, 100);
            this._messageControl1.Name = "messageControl1";
            this._messageControl1.RightBoxColor = System.Drawing.Color.FromArgb(192,206, 215);
            this._messageControl1.RightBoxTextColor = System.Drawing.Color.FromArgb(52,52, 52);
            this._messageControl1.AutoSize = true;
            this._messageControl1.Size = new System.Drawing.Size(200, 100);
            this._messageControl1.TabIndex = 0;
            this._messageControl1.Dock = DockStyle.Fill;
            this.ResumeLayout(false);

            this.MessagePanel.Controls.Add(_messageControl1);
        }
        
        public void AddIncomingMessage(string message, DateTime dateTime)
        {
            _messageControl1.Add(message, dateTime, MessageControl.BoxPositionEnum.Left);
        }

        public void AddSentMessage(string message, DateTime dateTime)
        {
            _messageControl1.Add(message, dateTime , MessageControl.BoxPositionEnum.Right);
        }

        public void InitUser(string username)
        {
            this.Text = username;
            this.labeHl1.Text = "You talks to: " + username;
        }
        
   

        public void CloseView()
        {
            this.Dispose();
        }


        private void sendNewMessageButton_Click(object sender, EventArgs e)
        {
            if(messageTextBox.Text == "") return;
            OnMessageSend.Invoke(this, new SendMessageArgs(messageTextBox.Text));
            messageTextBox.Text = "";
        }
    }
}