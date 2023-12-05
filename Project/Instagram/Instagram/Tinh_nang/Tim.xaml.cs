using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Tim.xaml
    /// </summary>
    public partial class Tim : UserControl
    {
        public Tim()
        {
            InitializeComponent();
        }
        ChromeDriver driver;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = "\n" + username_tb.Text;
            Ds.Text += a;
        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            driver=new ChromeDriver();
            driver.Url = "https://www.instagram.com/";
            driver.Navigate();
            System.Threading.Thread.Sleep(3000);

            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            /*usernameInput.SendKeys(username_tb.Text);*/
           
            /*passwordInput.SendKeys(password_tb.Text);*/

            // Click vào nút Đăng nhập
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            loginButton.Click();
            System.Threading.Thread.Sleep(5000);
            Tym("jennierubyjane");
        }
        private void Tym(string user)
        {

            driver.Navigate().GoToUrl("https://www.instagram.com/" + user + "/");
            System.Threading.Thread.Sleep(7000);
            IWebElement postSelector = driver.FindElement(By.CssSelector("div._aabd._aa8k._al3l a.x1i10hfl.xjbqb8w.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x1ypdohk.xt0psk2.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz._a6hd"));
            postSelector.Click();
            while (true)
            {

                ReadOnlyCollection<IWebElement> likeButtons = driver.FindElements(By.CssSelector("span._aamw svg[aria-label='Like']"));
                if (likeButtons.Count() > 0)
                {
                    IWebElement likeButton = driver.FindElement(By.CssSelector("span._aamw svg[aria-label='Like']"));
                    likeButton.Click();
                }
                By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                // Kiểm tra sự tồn tại của nút "Next"
                IList<IWebElement> nextButtons = driver.FindElements(nextButtonSelector);
                if (nextButtons.Count != 0)
                {
                    IWebElement nextButton = nextButtons[0];
                    nextButton.Click();
                }
                else break;
                System.Threading.Thread.Sleep(2000);

            }
        }
    }
}
