using Instagram.Tinh_nang;
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

namespace Instagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(btn_txt.Text=="Accept")
            {
                btn_txt.Text = "Đổi";
                tb1.IsEnabled = false;
                tb2.IsEnabled = false;
            } 
            else
            {
                tb1.IsEnabled = true;
                tb2.IsEnabled = true;
                btn_txt.Text = "Accept";
            }    
                
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Cào ảnh+comment")
            {

                Cao_anh_comment a = new Cao_anh_comment();
                View.Content = a.Content;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả tim")
            {

                Tim a = new  Tim();
                View.Content = a.Content;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình luận")
            {

               binhluan a = new binhluan();
                View.Content = a.Content;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng bài")
            {

                Dangbai a = new Dangbai();
                View.Content = a.Content;
            }
        }
    }
}
