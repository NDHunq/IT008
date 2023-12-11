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

        public Dangbai()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri image_Path;
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|JPG Files|*.jpg|PNG Files|*.png|JPEG Files|*.jpeg";
            ofd.ShowDialog();
           
           
            if (ofd.FileName != "")
            {
               
                Image img = new System.Windows.Controls.Image();
                {


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
            }
            else { }



            // Thêm đối tượng TextBlock mới vào ScrollViewer
            
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {


            ChromeDriver CD = new ChromeDriver();
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
            for (int i=1;i<dsuri.Count();i++)
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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"))).Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[2]/div/div[1]/div[1]/p"))).SendKeys(tb1_Copy.Text);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[5]/div/span[2]"))).Click();
            if(ck2.IsChecked == true)
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[5]/div[2]/div/div[1]/div/div[1]/div[2]/div/input"))).Click();
            if (ck1.IsChecked == true)
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[5]/div[2]/div/div[2]/div[1]/div[2]/div/input"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"))).Click();

        }










        }
    }

