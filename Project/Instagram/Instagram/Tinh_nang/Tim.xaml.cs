using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Tim.xaml
    /// </summary>
    public partial class Tim : UserControl
    {
        public string user_name;
        public string password;
        int soBaiTim = 0;
        public Tim()
        {
            InitializeComponent();
        }
        public void setUS(string _us)
        {
            user_name = _us;
        }
        public void setPW(string _pw)
        {
            password = _pw;
        }
        ChromeDriver driver;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Text or Word Document";
            ofd.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx, *.doc)|*.docx;*.doc";

            if (ofd.ShowDialog() == true)
            {
                string selectedFilePath = ofd.FileName;

                username_tb.Text = selectedFilePath;
            }

        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(username_tb.Text) && string.IsNullOrEmpty(Ds.Text))
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo");
            else
            {
                bool isNum = int.TryParse(timNumber.Text, out soBaiTim);
                if (rb_sl.IsChecked == true && !isNum)
                {
                    MessageBox.Show("Vui lòng chọn số lượng ảnh phù hợp");
                    return;
                }


                List<string> ListUser = new List<string>();
                if (!string.IsNullOrEmpty(username_tb.Text))
                {
                    FileStream fs = new FileStream(username_tb.Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    string l;
                    while ((l = sr.ReadLine()) != null)
                    {
                        ListUser.Add(l);
                    }
                }
                string[] temp = new string[100];
                temp = Ds.Text.Split(new string[] { "\n" }, StringSplitOptions.None);
                foreach (string s in temp)
                {
                    if (!string.IsNullOrEmpty(s))
                        ListUser.Add(s);
                }
                if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(user_name))
                {
                    if (ListUser.Count > 0)
                    {

                        driver = new ChromeDriver();
                        try
                        {


                            driver.Url = "https://www.instagram.com/";
                            driver.Navigate();
                            System.Threading.Thread.Sleep(3000);

                            IWebElement usernameInput = driver.FindElement(By.CssSelector("input[name='username']"));
                            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
                            usernameInput.SendKeys(user_name);
                            passwordInput.SendKeys(password);


                            // Click vào nút Đăng nhập
                            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
                            loginButton.Click();
                            System.Threading.Thread.Sleep(5000);
                            if (driver.Url == "https://www.instagram.com/")
                            {

                                throw new Exception("Đăng nhập thất bại!");
                            }

                            for (int i = 0; i < ListUser.Count; i++)
                            {
                                driver.ExecuteScript("window.open('');");
                                ReadOnlyCollection<string> tabs = driver.WindowHandles;
                                driver.SwitchTo().Window(tabs[tabs.Count - 1]);


                                try
                                {
                                    Tym(ListUser[i]);
                                }
                                catch { }
                            }

                            driver.Quit();
                            MessageBox.Show("Hoàn thành", "Thông báo");

                        }
                        catch (Exception ex)
                        {
                            driver.Quit();
                            MessageBox.Show(ex.Message, "Thông báo");
                            return;
                        }


                    }
                }
            }
        }
        private void Tym(string user)
        {


            int liked_post = 0;

            try
            {
                string target_user = user.Substring(0, 26);
                if (target_user == "https://www.instagram.com/")
                {
                    driver.Navigate().GoToUrl(user);
                }
                else
                    driver.Navigate().GoToUrl("https://www.instagram.com/" + user + "/");
            }
            catch
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/" + user + "/");
            }

            System.Threading.Thread.Sleep(7000);



            try
            {
                IWebElement postSelector = driver.FindElement(By.CssSelector("div._aabd._aa8k._al3l a.x1i10hfl.xjbqb8w.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x1ypdohk.xt0psk2.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz._a6hd"));
                postSelector.Click();
            }
            catch
            {
                return;
            }
            while (true)
            {

                ReadOnlyCollection<IWebElement> likeButtons = driver.FindElements(By.CssSelector("span._aamw svg[aria-label='Like']"));
                if (likeButtons.Count() > 0)
                {
                    IWebElement likeButton = driver.FindElement(By.CssSelector("span._aamw svg[aria-label='Like']"));
                    likeButton.Click();
                    System.Threading.Thread.Sleep(200);
                    liked_post++;
                }
                By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                // Kiểm tra sự tồn tại của nút "Next"
                IList<IWebElement> nextButtons = driver.FindElements(nextButtonSelector);
                if (nextButtons.Count != 0)
                {
                    IWebElement nextButton = nextButtons[0];
                    nextButton.Click();
                }
                else return;
                if (rb_sl.IsChecked == true)
                {
                    if (liked_post >= soBaiTim)
                        return;
                }
                System.Threading.Thread.Sleep(2000);

            }
        }
        private void rb_sl_Checked(object sender, RoutedEventArgs e)
        {
            timNumber.IsEnabled = true;

        }

        private void rb_sl_Unchecked(object sender, RoutedEventArgs e)
        {
            timNumber.IsEnabled = false;
            timNumber.Text = string.Empty;
        }
    }





}

