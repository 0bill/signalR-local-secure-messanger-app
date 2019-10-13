using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controllers;
using Client.Views;

namespace Client.Views
{
    public partial class TestView : Form, ITestView
    {
        private string test = "nie ma";
        private ITestController p;
        private int instance = new Random().Next(100000);

        public int inst
        {
            get { return instance;  }
        }

        public TestView()
        {
            Console.WriteLine("---------------------view " +instance.ToString() );

            InitializeComponent(test);
            
           
        }
        ~TestView()
        {
            Console.WriteLine("-------delete---------view " + instance.ToString());

        }

        public void setPresenter(ITestController p)
        {
            this.p = p;
         
        }
        public void chanetext(string test)
        {
            this.button1.Text = test;
        }


        public void show()
        {
            Console.WriteLine("Show" + instance.ToString());
            this.Show();
            this.Activate();
           // this.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var testPresenter = (TestController) p;
            this.button1.Text = testPresenter.getinstance.ToString();
        }

   
    }
}
