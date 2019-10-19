using System;
using System.Windows.Forms;
using Client.Views.Controls;

namespace Client.Views
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            PanelLoginUser panelUserItem = new PanelLoginUser();
            this.Controls.Add(panelUserItem);
            
        }
    }
}