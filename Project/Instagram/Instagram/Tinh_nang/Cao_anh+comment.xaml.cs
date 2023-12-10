using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Cao_anh_comment.xaml
    /// </summary>
    public partial class Cao_anh_comment : UserControl
    {
        public Cao_anh_comment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Text or Word Document";
            ofd.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx, *.doc)|*.docx;*.doc";

            if (ofd.ShowDialog() == true)
            {
                string selectedFilePath = ofd.FileName;

                tb1.Text = selectedFilePath;
            }
            else
            {
               
            }
        }

    }
}
