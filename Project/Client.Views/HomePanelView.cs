using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using Client.Forms;
using Client.Views.Controls;


namespace Client.Views
{
    public interface IHomePanelView : IView
    
    {
        event EventHandler OnUserClick; 
        event EventHandler UserLoginSubmit;
        void FillPanelWithUsers(List<string> users);
        void UserLoggedOn();
        void ShowLoginError(string msg);
        void ShowLoginMessage(string msg);
    }

    public partial class HomePanelView : Form, IHomePanelView
    {
        public event EventHandler OnUserClick;
        public event EventHandler UserLoginSubmit;
        private PanelLoginUser panelLoginUser;
        
        public HomePanelView()
        {
            InitializeComponent();
            panelLoginUser = new PanelLoginUser {Visible = true};
            panelLoginUser.OnUserSubmit += OnUserLoginSubmit;
            Controls.Add(panelLoginUser);
            PanelUsers.Visible = false;

        }

        private void OnUserLoginSubmit(object sender, EventArgs e)
        {
            UserLoginSubmit?.Invoke(sender, e);
        }

        public void FillPanelWithUsers(List<string> users)
        {
            this.SuspendLayout();
            for (var i = 0; i < users.Count(); i++)
            {
                PanelUserItem panelUserItem = new PanelUserItem();
                panelUserItem.setUser(users[i]);
                panelUserItem.Name = users[i];
                panelUserItem.Dock = DockStyle.Top;
                panelUserItem.DoubleClick += (sender, eventArgs) => { UserSelected(sender, eventArgs); };
                PanelUsers.Controls.Add(panelUserItem);
                
            }
            this.ResumeLayout(false);
        }

   

        public void UserLoggedOn()
        {
            
            panelLoginUser.Visible = false;
            PanelUsers.Visible = true;
        }

        public void ShowLoginError(string msg)
        {
            panelLoginUser.ShowError("Error: " + msg);
        }

        public void ShowLoginMessage(string msg)
        {
            panelLoginUser.ShowError(msg);
        }


        public void UserSelected(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(PanelUserItem))
            {
                
                var panelUserItem = (PanelUserItem) sender;
                Console.WriteLine("Hello" + panelUserItem.Name);
                OnUserClick(sender, e);
            }
        }

        
    }
}