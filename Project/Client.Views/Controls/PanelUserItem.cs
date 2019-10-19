using System;
using System.Windows.Forms;

namespace Client.Views.Controls
{
    public partial class PanelUserItem : UserControl
    {
        public PanelUserItem()
        {
            InitializeComponent();

            
            
            foreach (Control control in this.Controls)
            {
                control.DoubleClick += OnControlClick;
            }
        }

        public void setUser(string Username)
        {
            LabelUserName.SuspendLayout();
            LabelUserName.Text = Username;
            LabelUserName.ResumeLayout(false);
        }
        private void OnControlClick(object sender , EventArgs e)
        {
            OnDoubleClick(e);
        }
    }
}