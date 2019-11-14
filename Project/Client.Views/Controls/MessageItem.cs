using System.Drawing;
using System.Windows.Forms;


namespace Client.Views.Controls
{
    public partial class MessageItem : UserControl
    {
        public MessageItem()
        {
            InitializeComponent();
        }

        public void AddMessageFrom(Message message)
        {
            this.textLabel.Text = "";
            this.textLabel.TextAlign = ContentAlignment.MiddleRight;
            this.tableLayoutPanel1.BackColor = Color.Gainsboro;
        }

        public void AddMessageTo(Message message)
        {
            this.textLabel.Text = "";
            this.textLabel.TextAlign = ContentAlignment.MiddleRight;
            this.tableLayoutPanel1.BackColor = Color.Gainsboro;
        }
    }
}