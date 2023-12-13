using System;
using System.Collections.Generic;
using System.IO;
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
using Instagram.Tinh_nang.form;
using Microsoft.Win32;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for nuoiaccclone.xaml
    /// </summary>
    public partial class nuoiaccclone : UserControl
    {

        int itd = 0;

        public nuoiaccclone()
        {
            InitializeComponent();
            cbb1.SelectedIndex = 0;
         

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            add_Description a=new add_Description("Thêm discription rác");
            a.ShowDialog();

          
            string txt = a.EnteredContent;
            

            Label labeledText = new Label
            {
               
                Content = txt,
                ContextMenu = (ContextMenu)Resources["contextMenuDescription"],

                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10)
            };
        
            Border border = new Border
            {
                BorderBrush = Brushes.Black,   // Màu của đường viền
                BorderThickness = new Thickness(2),  // Độ dày của đường viền
                Child = labeledText  // Đặt Label làm con của Border
            };
          // Thêm đối tượng TextBlock mới vào ScrollViewer
            sd.Children.Add(border) ;
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
          
            

        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            add_Description a = new add_Description("Thêm comment rác");
            a.ShowDialog();


            string txt = a.EnteredContent;


            Label labeledText = new Label
            {
               
                Content = txt,
                ContextMenu = (ContextMenu)Resources["contextMenuComment"],

                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10)
            };
          
            Border border = new Border
            {
                BorderBrush = Brushes.Black,   // Màu của đường viền
                BorderThickness = new Thickness(2),  // Độ dày của đường viền
                Child = labeledText  // Đặt Label làm con của Border
            };
           
            // Thêm đối tượng TextBlock mới vào ScrollViewer
            sc.Children.Add(border);

        }
        private void EditComment_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedItem = FindClickedItem(sender);
            if (clickedItem != null)
            {
                add_Description a = new add_Description("Thêm comment rác");
                a.ShowDialog();


                string txt = a.EnteredContent;
                clickedItem.Content = txt;
            }
        }

        private void DeleteComment_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;

            sc.Children.Remove(parentBorder);
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new OpenFileDialog
            {
                Title = "Select a Folder",
                Filter = "Folders|*.folder",
                FileName = "SelectFolder",
                CheckFileExists = false,
                CheckPathExists = true
            };

            if (folderBrowserDialog.ShowDialog() == true)
            {
                string selectedFolder = System.IO.Path.GetDirectoryName(folderBrowserDialog.FileName);
                uri.Text = selectedFolder;
                // Sử dụng đường dẫn thư mục đã chọn ở đây
            }
        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            laplich a = new laplich();
            a.ShowDialog();
            string txt = a.EnteredContent;

           
            Label labeledText = new Label
            {
                Content = txt,
                ContextMenu = (ContextMenu)Resources["contextMenu"],
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10)
            };

            Border border = new Border
            {
                BorderBrush = Brushes.Black,   // Màu của đường viền
                BorderThickness = new Thickness(2),  // Độ dày của đường viền
                Child = labeledText  // Đặt Label làm con của Border
            };

            // Thêm đối tượng TextBlock mới vào ScrollViewer
            
            
            nv.Children.Add(border);
          
           

        }

        private void btn_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if(new_usr1_Copy1.Text=="start")
            {
                new_usr1_Copy1.Text = "stop";
                btn_Copy2.Background= new SolidColorBrush(Colors.Red);
            }   
            else
            {
                new_usr1_Copy1.Text = "start";
                btn_Copy2.Background = new SolidColorBrush(Colors.Green);
            }

        }   
        
        
        private static Label FindClickedItem(object sender)
        {
            var mi = sender as MenuItem;
            if (mi == null)
            {
                return null;
            }

            var cm = mi.CommandParameter as ContextMenu;
            if (cm == null)
            {
                return null;
            }

            return cm.PlacementTarget as Label;
        }
        
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedItem = FindClickedItem(sender);
            if (clickedItem != null)
            {
                laplich a = new laplich();
                a.ShowDialog();
                string txt = a.EnteredContent;
                clickedItem.Content = txt;
            }
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;

            nv.Children.Remove(parentBorder);
        }
        
        private void EditDesctiption_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedItem = FindClickedItem(sender);
            if (clickedItem != null)
            {
                
            }
        }

        private void DeleteDescripton_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;

            sd.Children.Remove(parentBorder);
        }
        
        
    }
}
