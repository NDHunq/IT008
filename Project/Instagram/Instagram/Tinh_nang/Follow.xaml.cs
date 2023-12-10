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
            else
            {

            }
        }
        private void Accept_Butt_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver CD = new ChromeDriver();
            CD.Navigate().GoToUrl("https://www.instagram.com/");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[1]/div/label/input")).SendKeys(Account);
            CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[2]/div/label/input")).SendKeys(Pass);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            string[] ListUser = User_Tbx.Text.Split(new string[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < ListUser.Length - 1; i++)
            {
                CD.ExecuteScript("window.open('');");
                ReadOnlyCollection<string> tabs = CD.WindowHandles;
                CD.SwitchTo().Window(tabs[tabs.Count - 1]);

                CD.Navigate().GoToUrl("https://www.instagram.com/" + ListUser[i] +"/");
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
        }
    }
}
/* test
 22520514@gm.uit.edu.vn
hhhhhhhh444
ndhunq
taylorswift
beyonce
 */