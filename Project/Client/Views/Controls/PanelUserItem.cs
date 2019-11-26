using System;
using System.Drawing;
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

        private void LabelUserName_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.CornflowerBlue;
        }


        private void PanelUserItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }
    }
}