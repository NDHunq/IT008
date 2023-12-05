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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for binhluan.xaml
    /// </summary>
    public partial class binhluan : UserControl
    {
        public string UserName;
        public string Password;
        
        public void SetUs(string us)
        {
            UserName= us;
        }
        public void SetPw(string pw) {
            Password= pw;
        }
        public binhluan()
        {
            InitializeComponent();
            UsernameCommented.IsEnabled = false;
            LinkCommented.IsEnabled = false;
            cbb.IsEnabled = false;
        }

        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var driver = new ChromeDriver();
            if (LinkCommented.IsEnabled)
            {
                //chuyển tới trang
                driver.Navigate().GoToUrl(LinkCommented.Text);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/nav/div[2]/div/div/div[2]/div/div/div/div[1]/a")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                
                //Điền username và password
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/div/div/div[1]/div[2]/form/div/div[1]/div/label/input")).SendKeys("duylam1412");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/div/div/div[1]/div[2]/form/div/div[2]/div/label/input")).SendKeys("duyhieu123");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                
                //Đăng nhập
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/div/div/div[1]/div[2]/form/div/div[3]/button")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
                
                //Bỏ qua thông báo
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div/div/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                // driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div/div/div[2]/div/div[4]/section/div/form/div/textarea")).SendKeys((UsernameBox.Text));
                
                //Điền cmt vào ô
                IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                textarea.Click();
                textarea = driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys(Comment.Text);
                
                //Gửi cmt
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div/div/div[2]/div/div[4]/section/div/form/div/div[2]/div")).Click();
            }
            
            

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameCommented.IsEnabled = true;
            LinkCommented.IsEnabled = false;
            cbb.IsEnabled = true;   
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            UsernameCommented.IsEnabled = false;
            LinkCommented.IsEnabled =true;
            cbb.IsEnabled = false;
        }
    }
}
