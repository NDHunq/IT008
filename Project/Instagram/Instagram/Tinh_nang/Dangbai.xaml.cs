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

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Dangbai.xaml
    /// </summary>
    public partial class Dangbai : UserControl
    {
        public string Account;
        public string Pass;

        public Dangbai()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|JPG Files|*.jpg|PNG Files|*.png|JPEG Files|*.jpeg";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                string tb_uri;
                tb_uri = ofd.FileName;
                Uri image_Path = new Uri(tb_uri);
                photo.Source = new BitmapImage(image_Path);
                photo.Stretch = System.Windows.Media.Stretch.UniformToFill;
            }
            else { }
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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Select from computer']"))).SendKeys("D:\\Ca nhan\\iCON\\6rn12okhovqnvoreknb6f47n17.png");
            var automation = new UIA3Automation();


            // Tìm cửa sổ (ví dụ: Notepad)
            var window= automation.GetDesktop().FindFirstDescendant(cf => cf.ByName("Open"));
            var cancelButton = window.FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Button).And(cf.ByName("Cancel")));

            // Nếu nút "Cancel" được tìm thấy, thực hiện click
            if (cancelButton != null)
            {
                cancelButton.Click();
            }
        }










        }
    }

