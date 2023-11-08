using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bai2._7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

        }
        public string a { get; set; }
        public string b { get; set; }
        public int time = 1;
        public int timeh, timem, times;
        public string Yc;

        private void button2_Click(object sender, EventArgs e)
        {

            label1.Text = "Vui lòng thêm yêu cầu mới!";
            timer1.Stop();
            button1.Text = "Thêm";
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text != "Vui lòng thêm yêu cầu mới!")
            {
                
                button2.Enabled = true;
                button1.Text = "Sửa";
            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập yêu cầu!");
            }
            else if (numericUpDown2.Value > 60)
            {
                MessageBox.Show("Vui lòng nhập phút <60");

            }
           else if (numericUpDown3.Value > 60)
            {
                MessageBox.Show("Vui lòng nhập giay <60");

            }
            else
            {
              
                time = int.Parse(numericUpDown1.Value.ToString()) * 3600 + int.Parse(numericUpDown2.Value.ToString()) * 60 + int.Parse(numericUpDown3.Value.ToString());
                Yc = comboBox1.Text;
              if(time < 0)
                {
                    MessageBox.Show("Vui long nhap thoi gian lon hon 0");
                }    
                    else {
                            timeh = time / 3600;
                            timem = (time - timeh * 3600) / 60;
                            times = time - timeh * 3600 - timem * 60;
                            label1.Text = "Máy tính sẽ " + comboBox1.Text + " trong \n                 " + timeh + "h" + timem + "m" + times + "s";
                            if (time == 0)
                            {
                                if (comboBox1.Text == "Shut down")
                                {
                                    Process.Start("shutdown", "/s /t 0");
                                }
                                else if (comboBox1.Text == "Restart")
                                {

                                    Process.Start("shutdown", "/r /t 0");
                                }
                                else if (comboBox1.Text == "Log out")
                                {
                                    Process.Start("shutdown", "/l");

                                }
                            }
                            else
                            {
                                timer1.Start();
                            }
                        }
              
                    
               
              
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            timeh = time / 3600;
            timem = (time- timeh*3600)/ 60;
            times = time - timeh * 3600 - timem * 60;

            label1.Text = "Máy tính sẽ " + Yc + " trong \n                 " + timeh + "h" +timem+"m"+times+"s";
            if (time == 0)
            {
                timer1.Stop();
                if (comboBox1.Text == "Shut down")
                {
                    Process.Start("shutdown", "/s /t 0");
                }
                else if (comboBox1.Text == "Restart")
                {
                    Process.Start("shutdown", "/r /t 0");
                }
                else if (comboBox1.Text == "Log out")
                {
                    Process.Start("shutdown", "/l");

                }


            }
        }
    }
}
    