using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Instagram.Tinh_nang.form
{
    /// <summary>
    /// Interaction logic for add_Description.xaml
    /// </summary>
    public partial class add_Description : Window
    {
       
        public string EnteredContent { get; private set; }
        public add_Description(string modau)
        {

            InitializeComponent();

            mdtxt.Text = modau;
            WindowStartupLocation = WindowStartupLocation.Manual;
        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (EnteredContent == "")

            {
                MessageBox.Show("Vui lòng nhập decription");

            }
            else
            {
                if (txt.Text != ""|| mdtxt.Text== "Thêm discription rác")
                {
                    EnteredContent = txt.Text;
                    Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            
            }

        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
