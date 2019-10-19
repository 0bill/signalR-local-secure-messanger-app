using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    public interface IForm : IView
    {

    }
    public partial class Form1 : Form, IForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
