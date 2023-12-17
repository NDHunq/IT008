using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using OpenQA.Selenium.Support.UI;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using FlaUI.Core.Definitions;
using Keyboard = FlaUI.Core.Input.Keyboard;
using FlaUI.Core.WindowsAPI;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;
using MenuItem = System.Windows.Controls.MenuItem;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Dangbai.xaml
    /// </summary>
    public partial class Dangbai : UserControl
    {
        public string Account;
        public string Pass;
        private List<string> dsuri = new List<string>();
      private int  truee=0;
        public Dangbai()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(dsuri.Count<=9)
            {
                Uri image_Path;
                Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select Image";
                ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|JPG Files|*.jpg|PNG Files|*.png|JPEG Files|*.jpeg";
                ofd.ShowDialog();


                if (ofd.FileName != "")
                {

                    Image img = new System.Windows.Controls.Image()
                    {

                        ContextMenu = (ContextMenu)Resources["contextMenu"]


                    };
                    Border border = new Border
                    {
                        BorderBrush = Brushes.Black,   // Màu của đường viền
                        BorderThickness = new Thickness(2),  // Độ dày của đường viền
                        Child = img // Đặt Label làm con của Border
                    };
                    string tb_uri = ofd.FileName;
                    dsuri.Add(tb_uri);
                    image_Path = new Uri(tb_uri);
                    img.Source = new BitmapImage(image_Path);
                    img.Stretch = System.Windows.Media.Stretch.UniformToFill;
                    im.Children.Add(border);
                    truee += 1;
                }
                else { }


            }
            else
            {
                MessageBox.Show("Thêm tối đa 10 ảnh", "Thông báo");
            }


            // Thêm đối tượng TextBlock mới vào ScrollViewer


        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver CD = new ChromeDriver();
          
                if(truee==0)
                {
                    CD.Quit();
                    MessageBox.Show("Vui lòng thêm ít nhất 1 ảnh!","Thông báo");
                }
                else
                {
                    try
                 {
                        WebDriverWait wait = new WebDriverWait(CD, TimeSpan.FromSeconds(10));
                        CD.Navigate().GoToUrl("https://www.instagram.com/");
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[1]/div/label/input")).SendKeys(Account);
                        CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[2]/div/label/input")).SendKeys(Pass);
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button")).Click();

                        IWebElement newPostButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='New post']")));
                        newPostButton.Click();
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Select from computer']"))).Click();
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        Keyboard.Type(dsuri[0]);

                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        Keyboard.Press(VirtualKeyShort.ENTER);
                        Thread.Sleep(TimeSpan.FromSeconds(1));


                        CD.FindElement(By.XPath("//*[@aria-label='Open media gallery']")).Click();
                        for (int i = 1; i < dsuri.Count(); i++)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            CD.FindElement(By.XPath("//*[@class='x9f619 xjbqb8w x78zum5 x168nmei x13lgxp2 x5pf9jr xo71vjh x1n2onr6 x1plvlek xryxfnj x1iyjqo2 x2lwn1j xeuugli xdt5ytf xqjyukv x1qjc9v5 x1oa3qoh x1nhvcw1']")).Click();



                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='Plus icon']"))).Click();
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            Keyboard.Type(dsuri[i]);

                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            Keyboard.Press(VirtualKeyShort.ENTER);
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div._ap97 > div > div > div > div._ac7b._ac7d > div > div"))).Click();
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div._ap97 > div > div > div > div._ac7b._ac7d > div > div"))).Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div.x15wfb8v.x3aagtl.x6ql1ns.x78zum5.xdl72j9.x1iyjqo2.xs83m0k.x13vbajr.x1ue5u6n > div.xhk4uv.x26u7qi.xy80clv.x9f619.x78zum5.x1n2onr6.x1f4304s > div > div > div > div._ac2p > div:nth-child(2) > div > div.x6s0dn4.x78zum5.x1n2onr6.xh8yej3 > div.xw2csxc.x1odjw0f.x1n2onr6.x1hnll1o.xpqswwc.xl565be.x5dp1im.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x1w2wdq1.xen30ot.x1swvt13.x1pi30zi.xh8yej3.x5n08af.notranslate"))).SendKeys(tb1_Copy.Text);


                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div._ap97 > div > div > div > div._ac7b._ac7d > div > div"))).Click();
                        IWebElement thanhcong = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div.xdl72j9.x1iyjqo2.xs83m0k.x15wfb8v.x3aagtl.xqbdwvv.x6ql1ns.x1cwzgcd > div.x6s0dn4.x78zum5.x5yr21d.xl56j7k.x1n2onr6.xh8yej3 > div > div:nth-child(2) > div > span")));
                    CD.Quit();
                }
                catch(Exception ex)
                {
                    CD.Quit();
                    MessageBox.Show("Đăng bài thất bại","Thông báo");
                }

                }
           

        }

        private void tb1_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
                Image clickedItem = FindClickedItem(sender);
                var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;
            dsuri.RemoveAt(im.Children.IndexOf(parentBorder) );
            im.Children.Remove(parentBorder);
        
          
        }
        private static Image FindClickedItem(object sender)
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

            return cm.PlacementTarget as Image;
        }

    }
}

