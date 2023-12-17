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
        Cao_anh_comment ca = new Cao_anh_comment();
        Tim tim = new Tim();
        binhluan bl = new binhluan();
        Dangbai db = new Dangbai();
        Follow fl = new Follow();
        nuoiaccclone nac = new nuoiaccclone();
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


                View.Content = ca.Content;
                ca.Account = tb1.Text;
                ca.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả Tim")
            {



                tim.setPW(tb2.Password);
                tim.setUS(tb1.Text);

                View.Content = tim.Content;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình Luận")
            {

                View.Content = bl.Content;
                bl.UserName = tb1.Text;
                bl.Password = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng Bài")
            {


                View.Content = db.Content;
                db.Account = tb1.Text;
                db.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
            {


                View.Content = fl.Content;
                fl.Account = tb1.Text;
                fl.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi Acc Clone")
            {


                View.Content = nac.Content;
                nac.Username = tb1.Text;
                nac.Password = tb2.Password;

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



                ca.Account = tb1.Text;
                ca.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả Tim")
            {


                if (!string.IsNullOrEmpty(tb1.Text) && !string.IsNullOrEmpty(tb2.Password))
                {
                    tim.setPW(tb2.Password);
                    tim.setUS(tb1.Text);
                }

            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình Luận")
            {

                bl.UserName = tb1.Text;
                bl.Password = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng Bài")
            {


                db.Account = tb1.Text;
                db.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
            {


                fl.Account = tb1.Text;
                fl.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi Acc Clone")
            {


                nac.Username = tb1.Text;
                nac.Password = tb2.Password;

            }
        }

      
        private void tb2_PasswordChanged_1(object sender, RoutedEventArgs e)
        {

            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Cào ảnh/Comment")
            {



                ca.Account = tb1.Text;
                ca.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Thả Tim")
            {


                if (!string.IsNullOrEmpty(tb1.Text) && !string.IsNullOrEmpty(tb2.Password))
                {
                    tim.setPW(tb2.Password);
                    tim.setUS(tb1.Text);
                }

            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Bình Luận")
            {

                bl.UserName = tb1.Text;
                bl.Password = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Đăng Bài")
            {


                db.Account = tb1.Text;
                db.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Follow")
            {


                fl.Account = tb1.Text;
                fl.Pass = tb2.Password;
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "Nuôi Acc Clone")
            {


                nac.Username = tb1.Text;
                nac.Password = tb2.Password;

            }

        }
    }
}
