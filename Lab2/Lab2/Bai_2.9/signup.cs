using System;
using System.IO;
using aes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            byte[] data = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] key = { 121, 28, 233, 92, 238, 119, 109, 222, 130, 123, 235, 175, 184, 197, 244, 64, 224, 77, 64, 66, 46, 170, 0, 100, 138, 115, 164, 170, 13, 189, 194, 82 };
            byte[] IV = { 170, 33, 113, 145, 71, 41, 157, 11, 93, 176, 124, 112, 5, 8, 210, 70 };
            using (Aes myAes = Aes.Create())
            {

                byte[] encrypted = AES1.EncryptStringToBytes_Aes(passwdBox.Text, key, IV);
                data = encrypted;
            }

            string filePath = Path.Combine(Application.StartupPath, "data.txt");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(userNameBox.Text+" "+data.ToString());
            }





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
