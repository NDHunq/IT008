using System;
using aes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

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
            if (userNameBox.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin", "Notice");
            }
            else if (Authentic(userNameBox.Text, textBox1.Text))
            {
                islogin = true;
                this.Close();
            }
            else
                MessageBox.Show("Không tìm thấy user!");
        }
        private bool Authentic(string username, string password)
        {
            //hash password
            string _hashpassword = "";
            byte[] encrypted = null;
            byte[] key = { 121, 28, 233, 92, 238, 119, 109, 222, 130, 123, 235, 175, 184, 197, 244, 64, 224, 77, 64, 66, 46, 170, 0, 100, 138, 115, 164, 170, 13, 189, 194, 82 };
            byte[] IV = { 170, 33, 113, 145, 71, 41, 157, 11, 93, 176, 124, 112, 5, 8, 210, 70 };
            using (Aes myAes = Aes.Create())
            {

                encrypted = AES1.EncryptStringToBytes_Aes(textBox1.Text, key, IV);
            }

            foreach (byte i in encrypted)
            {
                _hashpassword+= i.ToString("X2");
            }

            string filePath = Path.Combine(Application.StartupPath, "data.txt");
            List<string> user_pass = new List<string>();
            var logFile = File.ReadAllLines(filePath);
            foreach ( string line in logFile )
            {
                user_pass.Add(line);
            }
            string s = username + " " + _hashpassword;
            foreach ( string line in user_pass )
            {
                if(s == line)
                {
                    return true;
                }
            }
            return false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
