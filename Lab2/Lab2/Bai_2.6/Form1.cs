using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bai_2._6
{
    
    public partial class Form1 : Form
    {
        public static string conectionstring = @"Data Source=DESKTOP-MR3E6H4\SQLEXPRESS;Initial Catalog=QLSV_IT008;Integrated Security=True";
        SqlConnection connection = new SqlConnection(conectionstring);
        SqlCommand command;
         public Form1()
        {
            InitializeComponent();
        }

        private void ThemButt_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into DSSV values (" + (int.Parse)(MSSVTBx.Text) + ",'" + HoTenTBx.Text + "','" + MaLopTBx.Text + "'," + (float.Parse)(DiemToanTBx.Text) + "," + (float.Parse)(DiemAnhTBx.Text) + "," + (float.Parse)(DiemVanTBx.Text) + ")";
                command.ExecuteNonQuery();
                DSSV.DataSource = GetAllNV().Tables[0];
                MessageBox.Show("Thêm sinh viên thành công!!!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Thông tin sinh viên không hợp lệ!", "Thông báo");
            }
        }

        private void SuaButt_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "update DSSV set HOTEN='"+ HoTenTBx.Text + "' , MALOP='" + MaLopTBx.Text+"' , DIEMTOAN="+  (float.Parse)(DiemToanTBx.Text) + " , DIEMANH= " + (float.Parse)(DiemAnhTBx.Text) + " , DIEMVAN= " + (float.Parse)(DiemVanTBx.Text)+" WHERE MSSV="+(int.Parse)(MSSVTBx.Text);
                command.ExecuteNonQuery();
                DSSV.DataSource = GetAllNV().Tables[0];
                MessageBox.Show("Sửa thông tin sinh viên thành công!!!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Thông tin sinh viên không hợp lệ!", "Thông báo");
            }
        }
        private void XoaButt_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM DSSV WHERE MSSV='" + (int.Parse)(MSSVTBx.Text) + "'";
                command.ExecuteNonQuery();
                DSSV.DataSource = GetAllNV().Tables[0];
                MessageBox.Show("Xóa sinh viên thành công!!!", "Thông báo");
            }
            catch 
            {
                MessageBox.Show("Thông tin sinh viên không hợp lệ!", "Thông báo");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            DSSV.DataSource = GetAllNV().Tables[0];
        }
        private void Form1_Leave(object sender, EventArgs e)
        {
            connection.Close();
        }
        DataSet GetAllNV()
        {
            DataSet result = new DataSet();
            command = connection.CreateCommand();
            command.CommandText = "select* from DSSV";
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand= command;
            adapter.Fill(result);
            return result;
        }

        private void DSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DSSV.CurrentRow.Index;
            MSSVTBx.Text = DSSV.Rows[i].Cells[0].Value.ToString();
            HoTenTBx.Text= DSSV.Rows[i].Cells[1].Value.ToString();
            MaLopTBx.Text = DSSV.Rows[i].Cells[2].Value.ToString();
            DiemToanTBx.Text = DSSV.Rows[i].Cells[3].Value.ToString();
            DiemAnhTBx.Text = DSSV.Rows[i].Cells[4].Value.ToString();
            DiemVanTBx.Text = DSSV.Rows[i].Cells[5].Value.ToString();
        }

    }
}
