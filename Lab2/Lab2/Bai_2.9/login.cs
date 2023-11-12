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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        
        public bool islogin=false;

        private void loginBut_Click(object sender, EventArgs e)
        {

            islogin = true;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Create a new account!", "Help");
        }

        private void signup_Click(object sender, EventArgs e)
        {
            islogin = true;
            this.Hide();
            
            signup su= new signup();
            su.ShowDialog();
            this.Close();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!islogin)
            {
                Application.Exit();
            }
        }
    }
}
