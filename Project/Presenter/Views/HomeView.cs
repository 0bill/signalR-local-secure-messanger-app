using Presenter.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presenter
{
    public partial class HomeView : Form, IHomeView
    {

        public event EventHandler dzwoni;
        private int instance;

        public HomeView()
        {

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EventHelper.Raise(dzwoni, this, e);

        }
    }
}
