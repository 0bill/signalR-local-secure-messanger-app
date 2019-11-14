using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using Client.Forms;
using Client.Views.Controls;
using Domain;

namespace Client.Views
{
    public interface IHomePanelView : IView
    
    {
        event EventHandler OnUserClick; 
        event EventHandler UserLoginSubmit;
        event EventHandler LogoutUser;
        void FillPanelWithUsers(List<User> users);
        void UserLoggedOn();
        void ShowLoginError(string msg);
        void ShowLoginMessage(string msg);
        void UserLoggedOFF();
    }

    public partial class HomePanelView : Form, IHomePanelView
    {
        public event EventHandler OnUserClick;
        public event EventHandler UserLoginSubmit;
        public event EventHandler LogoutUser;
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

        public void FillPanelWithUsers(List<User> users)
        {
            if(users==null)
                return;
            this.SuspendLayout();
            for (var i = 0; i < users.Count(); i++)
            {
                PanelUserItem panelUserItem = new PanelUserItem();
                panelUserItem.setUser(users[i].Username);
                panelUserItem.Name = users[i].Id.ToString();
                panelUserItem.Dock = DockStyle.Top;
                panelUserItem.DoubleClick += (sender, eventArgs) => { UserSelected(sender, eventArgs); };
                PanelUsers.Controls.Add(panelUserItem);
                
            }
            this.ResumeLayout(false);
        }

   

        public void UserLoggedOn()
        {
            this.SuspendLayout();
            panelLoginUser.Visible = false;
            PanelUsers.Visible = true;
            TopMenu.Visible = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        public void UserLoggedOFF()
        {

            panelLoginUser.Visible = true;
            PanelUsers.Visible = false;
            TopMenu.Visible = false;
            //PanelUsers.Controls.Clear();
            
            for (var ii = PanelUsers.Controls.Count - 1; ii >= 0; --ii) { 
                var wdc = PanelUsers.Controls[ii] as PanelUserItem;
                wdc.Visible = false;
                wdc.Dispose();
            }
            
        }


        public void ShowLoginError(string msg)
        {
            panelLoginUser.ShowError("Error: " + msg);
        }

        public void ShowLoginMessage(string msg)
        {
            panelLoginUser.ShowError(msg);
        }


        private void UserSelected(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(PanelUserItem))
            {
                var panelUserItem = (PanelUserItem) sender;
                OnUserClick(sender, e);
            }
        }


        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogoutUser(sender, e);
        }
    }
}