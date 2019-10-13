using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.Views
{
    public interface IHomeView : IView
    {
        event EventHandler dzwoni;
    }

    public partial class HomeView : Form, IHomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public event EventHandler dzwoni;
    }
}
