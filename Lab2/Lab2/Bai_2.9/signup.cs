using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEdit
{
    public partial class signup : Form
    {
         public bool isSUclosed = false;
        public signup()
        {
            InitializeComponent();
        }
        bool isSignup = false;
        private void button1_Click(object sender, EventArgs e)
        {
            isSignup = true;
            this.Close();
        }

        private void signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!isSignup) {
                this.Hide();
                login lg=new login();
                lg.ShowDialog();
            }
        }
    }
}
