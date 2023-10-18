using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bai_2._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Random random = new Random();
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Tạo một đối tượng Graphics từ PaintEventArgs
            Graphics g = e.Graphics;
            // Chọn một màu ngẫu nhiên
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            Brush brush = new SolidBrush(randomColor);

            // Tính toán vị trí x, y ngẫu nhiên
            int x = random.Next(formWidth);
            int y = random.Next(formHeight);

            // Vẽ chuỗi "Paint Event" tại vị trí x, y
            g.DrawString("Paint Event", this.Font, brush, x, y);
        }
    }
}
