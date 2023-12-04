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
    /// Interaction logic for binhluan.xaml
    /// </summary>
    public partial class binhluan : UserControl
    {
        public binhluan()
        {
            InitializeComponent();
            tb1.IsEnabled = false;
            tb2.IsEnabled = false;
            cbb.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            tb1.IsEnabled = true;
            tb2.IsEnabled = false;
            cbb.IsEnabled = true;   
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            tb1.IsEnabled = false;
            tb2.IsEnabled =true;
            cbb.IsEnabled = false;
        }
    }
}
