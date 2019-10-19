using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

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
                ShowError("Please fill username");
            if (password == string.Empty)
                ShowError("Please fill password");

            var eventArgs = new OnUserSubmitEventArgs(username, password);
            OnUserSubmit(sender, eventArgs);
            
        }

        public void ShowError(string msg)
        {
            this.ErrorLabel.Text = "Error: " + msg;
            this.PanelError.Visible = true;
        }
    }
}