using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Collections.ObjectModel;
using FlaUI.Core.WindowsAPI;
using System.Xml.Linq;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Cao_anh_comment.xaml
    /// </summary>
    public partial class Cao_anh_comment : UserControl
    {
        public string Account;
        public string Pass;
        public Cao_anh_comment()
        {
            InitializeComponent();
        }

        private void accept_butt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void run_butt_Click(object sender, RoutedEventArgs e)
        {
            string saveFolderPath = @"C:\Users\PC\Documents\ListImage";
            /////////////////////////////////////
            ChromeDriver CD = new ChromeDriver();
            CD.Navigate().GoToUrl("https://www.instagram.com/");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[1]/div/label/input")).SendKeys(Account);
            CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[2]/div/label/input")).SendKeys(Pass);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            //////////////////////////////////////
            CD.Navigate().GoToUrl("https://www.instagram.com/" + this.user_name.Text + "/");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            //Chọn bài đăng đầu tiên
            IWebElement postSelector = CD.FindElement(By.CssSelector("div._aabd._aa8k._al3l a.x1i10hfl.xjbqb8w.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x1ypdohk.xt0psk2.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz._a6hd"));
            postSelector.Click();
            /////
            int AnhDaCao = 0;
            while (true)
            {
                try
                {
                    IWebElement imgElement = CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe.x1qjc9v5.xjbqb8w.x1lcm9me.x1yr5g0i.xrt01vj.x10y3i5r.xr1yuqi.xkrivgy.x4ii5y1.x1gryazu.x15h9jz8.x47corl.xh8yej3.xir0mxb.x1juhsu6 > div > article > div > div._aatk._aatl > div > div._aamn > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x10l6tqk.x1ey2m1c.x13vifvy.x17qophe.xds687c.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1 > div > div > div > ul > li:nth-child(2) > div > div > div > div > div._aagv > img"));
                    string imageUrl = imgElement.GetAttribute("src");

                    ////
                    FileDownloader downloader = new FileDownloader();
                    string fileName = System.IO.Path.GetFileName("image" + AnhDaCao + ".jpg");
                    string imagePath = System.IO.Path.Combine(saveFolderPath, fileName);
                    downloader.DownloadFile(imageUrl, imagePath);
                    AnhDaCao++;
                }
                catch { }
                By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                 //Xem coi có nút next khum
                IList<IWebElement> nextButtons = CD.FindElements(nextButtonSelector);
                if (nextButtons.Count != 0)
                {
                    IWebElement nextButton = nextButtons[0];
                    nextButton.Click();
                }
                else
                    break;
                if (AnhDaCao > 10)
                    break;
                System.Threading.Thread.Sleep(2000);

            }
        }
    }
    public class FileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
        }
    }
}
