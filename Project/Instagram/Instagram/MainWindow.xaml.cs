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
       
       

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            // animation đóng form
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush(Colors.White);
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btn_txt.Text == "Accept")
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
            if (tb1.Text==""||tb2.Text=="")
            {
                MessageBox.Show("Vui long nhap day du thong tin");
               
            }
            else
            {


                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Cào ảnh+comment")
                {

                    Cao_anh_comment a = new Cao_anh_comment();
                    View.Content = a.Content;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả tim")
                {

                    Tim a = new Tim();
                    if (!tb1.IsEnabled && !tb2.IsEnabled)
                    {
                        a.setPW(tb2.Text);
                        a.setUS(tb1.Text);
                    }
                    View.Content = a.Content;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình luận")
                {
                    binhluan bl = new binhluan();
                    if (!tb1.IsEnabled && !tb2.IsEnabled)
                    {
                        bl.SetUs(tb1.Text);
                        bl.SetPw(tb2.Text);
                    }
                    View.Content = bl.Content;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng bài")
                {

                    Dangbai a = new Dangbai();
                    View.Content = a.Content;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
                {

                    Follow a = new Follow();
                    View.Content = a.Content;
                    a.Account = tb1.Text;
                    a.Pass = tb2.Text;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi acc clone")
                {

                    nuoiaccclone a = new nuoiaccclone();
                    View.Content = a.Content;
                 
                }
            }
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
