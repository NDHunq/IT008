using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using static System.Net.Mime.MediaTypeNames;


namespace Instagram.Tinh_nang.form
{
    /// <summary>
    /// Interaction logic for laplich.xaml
    /// </summary>
    public partial class laplich : Window
    {
        public string EnteredContent { get; private set; }
         public int truee=0;
         public bool isAccept = false;
        public laplich()
        {
            InitializeComponent();
            hd.SelectedIndex = 0;
            
        }


        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Kiểm tra xem ký tự mới nhập vào có phải là số hay không
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true; // Ngăn chặn ký tự không phải số được nhập vào
            }
        }

        public Tinhnangnuoiclone getTinhNang()
        {
            Tinhnangnuoiclone a = new Tinhnangnuoiclone(dateTimePicker.Text, hd.Text);
            return a;
        }
        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
             if(truee==1 && dateTimePicker.Text!="")
             {
                EnteredContent = hd.Text + " vào thời điểm: " + dateTimePicker.Text;
                truee = 0;
                isAccept = true;
                Close();
                
             }
             else
             {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
             }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            truee = 1;
        }
    }
    
}
