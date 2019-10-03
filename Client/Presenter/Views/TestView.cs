using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter.Presenters;

namespace Presenter.Views
{
    public partial class TestView : Form, ITestView
    {
        private string test = "nie ma";
        private ITestPresenter p;
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

        public void setPresenter(ITestPresenter p)
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
            var testPresenter = (TestPresenter) p;
            this.button1.Text = testPresenter.getinstance.ToString();
        }

   
    }
}
