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
using OpenQA.Selenium.DevTools.V117.FedCm;
using OpenQA.Selenium.Interactions;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for binhluan.xaml
    /// </summary>
    public partial class binhluan : UserControl
    {
        public string UserName ;
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
            ChromeDriver chromeDriver = new ChromeDriver();
            _Login(chromeDriver);
            if (LinkCommented.IsEnabled)
            {
                _LinkCommented(chromeDriver);
            }
            else if (UsernameCommented.IsEnabled)
            {
                if(cbb.Text == "Comment bài gần nhất")
                    _FirstPostComment(chromeDriver);
                else if (cbb.Text == "Comment tất cả")
                {
                    _AllPostComment(chromeDriver);
                }
            }
            Thread.Sleep(TimeSpan.FromSeconds(5));
            chromeDriver.Quit();
        }

        #region Login

        private void _Login(ChromeDriver driver)
        {
            try
            {
                //chuyển tới trang
                driver.Navigate().GoToUrl("https://www.instagram.com/");
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                //Điền username và password
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[1]/div/label/input")).SendKeys(UserName);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[2]/div/label/input")).SendKeys(Password);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            
                //Đăng nhập
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[3]/button/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
            
        #region AllPostComment

        private void _AllPostComment(ChromeDriver driver)
        {
            try
            {
            
                driver.Navigate().GoToUrl("https://www.instagram.com/duylam1412/");
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[2]/article/div/div/div/div[1]/a/div[1]/div[2]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                
                while (true)
                {
                    //Điền cmt vào ô
                    IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                    textarea.Click();
                    textarea = driver.FindElement(By.TagName("textarea"));
                    textarea.SendKeys(Comment.Text);
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    //Gửi cmt
                    Actions actions = new Actions(driver);
                    actions.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    if (!_isFoundElement(driver))
                        break;
                    NextButtonClick(driver); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        private bool _isFoundElement(ChromeDriver chromeDriver)
        {
            try
            {
                By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                chromeDriver.FindElement(nextButtonSelector);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private void NextButtonClick(ChromeDriver chromeDriver)
        {
            By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
            chromeDriver.FindElement(nextButtonSelector).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        #endregion

        #region FirstPostComment

        private void _FirstPostComment(ChromeDriver driver)
        {
            try
            {
            
                driver.Navigate().GoToUrl("https://www.instagram.com/" + UsernameCommented.Text + "/");
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[2]/article/div/div/div/div[1]/a/div[1]/div[2]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                //Điền cmt vào ô
                IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                textarea.Click();
                textarea = driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys(Comment.Text);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                //Gửi cmt
                Actions actions = new Actions(driver);
                actions.SendKeys(Keys.Enter).Perform();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        #endregion

        #region LinkCommented

        private void _LinkCommented(ChromeDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl(LinkCommented.Text);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                //Điền cmt vào ô
                IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                textarea.Click();
                textarea = driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys(Comment.Text);
                
                //Gửi cmt
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div/div/div[2]/div/div[4]/section/div/form/div/div[2]/div")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        #endregion
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameCommented.IsEnabled = true;
            LinkCommented.IsEnabled = false;
            cbb.IsEnabled = true;
            cbb.Text = "Comment bài gần nhất";
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            UsernameCommented.IsEnabled = false;
            LinkCommented.IsEnabled =true;
            cbb.IsEnabled = false;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            bd1.Visibility = Visibility.Collapsed;
            bd2.Visibility = Visibility.Visible;
        }
    

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            bd1.Visibility = Visibility.Visible;
            bd2.Visibility = Visibility.Collapsed;
        }

    }
}
