using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Client.Views.Events;

namespace Client.Views.Controls
{
    
    public partial class PanelLoginUser : UserControl
    {
        public event EventHandler OnUserSubmit;
        public PanelLoginUser()
        {
            InitializeComponent();
        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            this.PanelError.Visible = false;
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            if (username == string.Empty)
            {
                ShowError("Please fill username");
                return;
            }
            if (password == string.Empty)
            {
                ShowError("Please fill password");
                return;
            }


            var eventArgs = new OnUserSubmitEventArgs(username, password);
            OnUserSubmit(sender, eventArgs);
            
        }

        public void ShowError(string msg)
        {
            this.ErrorLabel.Text = msg;
            this.PanelError.Visible = true;
        }

        private void PanelLoginUser_VisibleChanged(object sender, EventArgs e)
        {
            this.PanelError.Visible = false;
            this.textBoxUsername.Text = "";
            this.textBoxPassword.Text = "";
        }
    }
}