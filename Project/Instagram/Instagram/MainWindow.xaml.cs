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
            cbb.SelectedIndex = 0;
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

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          

                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Cào ảnh/Comment")
                {

                    Cao_anh_comment a = new Cao_anh_comment();
                    View.Content = a.Content;
                    a.Account = tb1.Text;
                    a.Pass = tb2.Password;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả Tim")
                {

                    Tim a = new Tim();
                    View.Content = a.Content;
                    
                    a.user_name = tb1.Text;
                    a.password = tb2.Password;
                    
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình Luận")
                {
                    binhluan bl = new binhluan();
                    View.Content = bl.Content;
                    bl.UserName = tb1.Text;
                    bl.Password = tb2.Password;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng Bài")
                {

                    Dangbai a = new Dangbai();
                    View.Content = a.Content;
                    a.Account = tb1.Text;
                    a.Pass = tb2.Password;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
                {

                    Follow a = new Follow();
                    View.Content = a.Content;
                    a.Account = tb1.Text;
                    a.Pass = tb2.Password;
                }
                if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi Acc Clone")
                {

                    nuoiaccclone a = new nuoiaccclone();
                    View.Content = a.Content;
                    a.Username = tb1.Text;
                    a.Password = tb2.Password;
                 
                }
            
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Cào ảnh/Comment")
            {

                Cao_anh_comment a = new Cao_anh_comment();
                View.Content = a.Content;
                a.Account = tb1.Text;
                a.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả Tim")
            {

                Tim a = new Tim();
                View.Content = a.Content;
                a.user_name = tb1.Text;
                a.password = tb2.Password;
                
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình Luận")
            {
                binhluan bl = new binhluan();
                View.Content = bl.Content;
                bl.UserName = tb1.Text;
                bl.Password = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng Bài")
            {

                Dangbai a = new Dangbai();
                View.Content = a.Content;
                a.Account = tb1.Text;
                a.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
            {

                Follow a = new Follow();
                View.Content = a.Content;
                a.Account = tb1.Text;
                a.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi Acc Clone")
            {

                nuoiaccclone a = new nuoiaccclone();
                View.Content = a.Content;
                a.Username = tb1.Text;
                a.Password = tb2.Password;

            }
        }

        

        private void tb2_PasswordChanged_1(object sender, RoutedEventArgs e)
        {


            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Cào ảnh/Comment")
            {

                Cao_anh_comment a = new Cao_anh_comment();
                View.Content = a.Content;
                a.Account = tb1.Text;
                a.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả Tim")
            {

                Tim a = new Tim();
                View.Content = a.Content;
                a.user_name = tb1.Text;
                a.password = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình Luận")
            {
                binhluan bl = new binhluan();
                View.Content = bl.Content;
                bl.UserName = tb1.Text;
                bl.Password = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng Bài")
            {

                Dangbai a = new Dangbai();
                View.Content = a.Content;
                a.Account = tb1.Text;
                a.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
            {

                Follow a = new Follow();
                View.Content = a.Content;
                a.Account = tb1.Text;
                a.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi Acc Clone")
            {

                nuoiaccclone a = new nuoiaccclone();
                View.Content = a.Content;
                a.Username = tb1.Text;
                a.Password = tb2.Password;

            }
        }
    }
}
