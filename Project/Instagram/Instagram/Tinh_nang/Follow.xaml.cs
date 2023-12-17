using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Follow.xaml
    /// </summary>
    
    public partial class Follow : UserControl
    {
        public int index = 0;
        public string Account;
        public string Pass;

        public Follow()
        {
            InitializeComponent();
        }

        private void add_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Text or Word Document";
            ofd.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx, *.doc)|*.docx;*.doc";

            if (ofd.ShowDialog() == true)
            {
                string selectedFilePath = ofd.FileName;

                add_tbx.Text = selectedFilePath;
            }
            //sc.Visibility = Visibility.Visible;
        }
        private void Accept_Butt_Click(object sender, RoutedEventArgs e)
        {
            if (User_Tbx.Text == "" && add_tbx.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
            else
            {
                ChromeDriver CD = new ChromeDriver();
                try
                {
                    CD.Navigate().GoToUrl("https://www.instagram.com/");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[1]/div/label/input")).SendKeys(Account);
                    CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[2]/div/label/input")).SendKeys(Pass);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    if (CD.Url == "https://www.instagram.com/")
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        throw new Exception();
                    }
                    List<string> ListUser = new List<string>();
                    if (add_tbx.Text != "")
                    {
                        FileStream fs = new FileStream(add_tbx.Text, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);
                        string l;
                        while ((l = sr.ReadLine()) != null)
                        {
                            ListUser.Add(l);
                        }
                    }
                    string[] temp = new string[100];
                    temp = User_Tbx.Text.Split(new string[] { "\n" }, StringSplitOptions.None);
                    foreach (string s in temp)
                    {
                        ListUser.Add(s);
                    }

                    for (int i = 0; i < ListUser.Count; i++)
                    {
                        CD.ExecuteScript("window.open('');");
                        ReadOnlyCollection<string> tabs = CD.WindowHandles;
                        CD.SwitchTo().Window(tabs[tabs.Count - 1]);
                        try
                        {
                            try
                            {
                                string target_user = ListUser[i].Substring(0, 26);
                                if (target_user == "https://www.instagram.com/")
                                {
                                    CD.Navigate().GoToUrl(ListUser[i]);
                                }
                                else
                                    CD.Navigate().GoToUrl("https://www.instagram.com/" + ListUser[i] + "/");
                            }
                            catch
                            {
                                CD.Navigate().GoToUrl("https://www.instagram.com/" + ListUser[i] + "/");
                            }

                            Thread.Sleep(TimeSpan.FromSeconds(7));
                            try
                            {   //có tích xanh
                                CD.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/header/section/div[1]/div[2]/div/div[1]/button")).Click();
                                Thread.Sleep(TimeSpan.FromSeconds(2));
                            }
                            catch
                            {   //không tích xanh
                                CD.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/header/section/div[1]/div[1]/div/div[1]/button")).Click();
                                Thread.Sleep(TimeSpan.FromSeconds(2));
                            }
                        }
                        catch
                        {
                            MessageBox.Show("User " + ListUser[i] + " không tồn tại!");
                        }
                    }
                    CD.Quit();
                    MessageBox.Show("Thành công", "Thông báo");
                }
                catch
                {
                    CD.Quit();
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo");
                }
            }
        }
    }
}
/* test
duy07092004@gmail.com
hhhhhhhh444
ndhunq
taylorswift
beyonce
 */