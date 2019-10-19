using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Client.Views.Controls;

namespace Client.Views
{
    public interface IHomePanelView : IView
    {
        event EventHandler OnUserClick;
        void FillPanelWithUsers(List<string> users);
    }

    public partial class HomePanelView : Form, IHomePanelView
    {
        public event EventHandler OnUserClick;
        
        public HomePanelView()
        {
            InitializeComponent();
            
        }

        public void FillPanelWithUsers(List<string> users)
        {
            this.SuspendLayout();
            for (var i = 0; i < users.Count(); i++)
            {
                Console.WriteLine(i);
                PanelUserItem panelUserItem = new PanelUserItem();
                panelUserItem.setUser(users[i]);
                panelUserItem.Name = users[i];
                panelUserItem.Dock = DockStyle.Top;
                panelUserItem.DoubleClick += (sender, eventArgs) => { UserSelected(sender, eventArgs); };
                PanelUsers.Controls.Add(panelUserItem);
                
            }
            this.ResumeLayout(false);
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