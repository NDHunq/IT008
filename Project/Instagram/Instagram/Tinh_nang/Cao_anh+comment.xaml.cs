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
using System.Net.PeerToPeer;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Keyboard = FlaUI.Core.Input.Keyboard;
using OpenQA.Selenium.Interactions;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Cao_anh_comment.xaml
    /// </summary>
    public partial class Cao_anh_comment : UserControl
    {
        public string Account;
        public string Pass;
        ChromeDriver CD;
        string saveFolderPath;
        public Cao_anh_comment()
        {
            InitializeComponent();
        }

        private void accept_butt_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new OpenFileDialog
            {
                Title = "Select a Folder",
                Filter = "Folders|*.folder",
                FileName = "SelectFolder",
                CheckFileExists = false,
                CheckPathExists = true
            };

            if (folderBrowserDialog.ShowDialog() == true)
            {
                string selectedFolder = System.IO.Path.GetDirectoryName(folderBrowserDialog.FileName);
                file_output_path.Text = selectedFolder;
            }
        }
        private void run_butt_Click(object sender, RoutedEventArgs e)
        {
            int loi = 0;
            if (Account==""|| Pass==""||this.user_name.Text == "" || this.file_output_path.Text == "" || (Cao_Anh.IsChecked == true && SoAnhRadio.IsChecked == true && SoAnhTbx.Text == "") || (Cao_BL.IsChecked == true && SoCmtRadio.IsChecked == true && SoCmtTbx.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                try
                {
                    string tempPath = file_output_path.Text;
                    saveFolderPath = tempPath.Replace(@"\", @"\\");
                    CD = new ChromeDriver();
                    //Log in 
                    loi = 1;
                    CD.Navigate().GoToUrl("https://www.instagram.com/");
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[1]/div/label/input")).SendKeys(Account);
                    CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[2]/div/label/input")).SendKeys(Pass);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    CD.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    if (CD.Url == "https://www.instagram.com/")
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        throw new Exception();
                    }
                    //Go to target 
                    try
                    {
                        string target_user = this.user_name.Text.Substring(0, 26);
                        if (target_user == "https://www.instagram.com/")
                        {
                            CD.Navigate().GoToUrl(user_name.Text);
                        }
                        else
                            CD.Navigate().GoToUrl("https://www.instagram.com/" + this.user_name.Text + "/");
                    }
                    catch
                    {
                        CD.Navigate().GoToUrl("https://www.instagram.com/" + this.user_name.Text + "/");
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    loi = 2;
                    //Choosing first post        
                    IWebElement postSelector = CD.FindElement(By.CssSelector("div._aabd._aa8k._al3l a.x1i10hfl.xjbqb8w.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x1ypdohk.xt0psk2.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1a2a7pz._a6hd"));
                    postSelector.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(6));
                    //*****************************************************************************************************
                    if (this.Cao_Anh.IsChecked == true)
                    {
                        int AnhDaCao = 0;
                        int stopImg = 0;
                        int stopCmt = 0;
                        int CmtDaCao = 0;
                        int CmtDaLoad = 0;
                        int PostIndex = 1;
                        int enableCmt = 1;
                        while (true)
                        {

                            if (this.Cao_BL.IsChecked == true)
                            {
                                if (stopCmt == 1 && stopImg == 1)
                                    break;
                                if (stopCmt == 0)
                                {
                                    if (enableCmt == 1)
                                    {
                                        CmtEachPost(ref CmtDaCao, ref CmtDaLoad, ref stopCmt, ref PostIndex);
                                        enableCmt = 0;
                                    }

                                }
                            }
                            try
                            {
                                if (this.Cao_BL.IsChecked == false && stopImg == 1)
                                    break;
                                if (stopImg == 0)
                                {
                                    ImgEachPost(ref AnhDaCao, ref stopImg);
                                    System.Threading.Thread.Sleep(500);
                                }

                            }
                            catch { }
                            {
                                //Xem coi có nút next khum
                                By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                                IList<IWebElement> nextButtonsFarent = CD.FindElements(nextButtonSelector);
                                if (nextButtonsFarent.Count != 0)
                                {
                                    IWebElement nextButton = nextButtonsFarent[0];
                                    nextButton.Click();
                                    PostIndex++;
                                    enableCmt = 1;
                                }
                                else
                                    break;

                            }
                            if (this.Cao_BL.IsChecked == true && stopImg == 1 && stopCmt == 0)
                            {
                                By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                                IList<IWebElement> nextButtonsFarent = CD.FindElements(nextButtonSelector);
                                if (nextButtonsFarent.Count != 0)
                                {
                                    IWebElement nextButton = nextButtonsFarent[0];
                                    nextButton.Click();
                                    PostIndex++;
                                    enableCmt = 1;
                                }
                                else
                                    break;
                            }
                        }
                        CD.Quit();
                        MessageBox.Show("Done!", "Thông báo");
                    }
                    //*****************************************************************************************
                    if (this.Cao_BL.IsChecked == true && this.Cao_Anh.IsChecked == false)
                    {
                        int CmtDaCao = 0;
                        int CmtDaLoad = 0;
                        int stop = 0;
                        int PostIndex = 1;
                        while (true)
                        {
                            CmtEachPost(ref CmtDaCao, ref CmtDaLoad, ref stop, ref PostIndex);
                            if (stop == 1)
                                break;
                            By nextButtonSelector = By.CssSelector("svg[aria-label='Next']");
                            IList<IWebElement> nextButtonsFarent = CD.FindElements(nextButtonSelector);
                            if (nextButtonsFarent.Count != 0)
                            {
                                IWebElement nextButton = nextButtonsFarent[0];
                                nextButton.Click();
                            }
                            else
                                break;
                            PostIndex++;
                        }
                        CD.Quit();
                        MessageBox.Show("Thành công", "Thông báo");
                    }
                }
                catch
                {
                    CD.Quit();
                    if (loi == 1)
                        MessageBox.Show("Đăng nhập thất bại!", "Thông báo");
                    if (loi == 2)
                        MessageBox.Show("User không tồn tại hoặc không có bài đăng nào !", "Thông báo");
                }

            }

        }
        //Crawl cmt mỗi post
        public void CmtEachPost(ref int CmtDaCao, ref int CmtDaLoad, ref int stop, ref int PostIndex)
        {
            LoadCmts(ref CmtDaLoad);
            IList<IWebElement> commentElements = CD.FindElements(By.CssSelector("span._ap3a._aaco._aacu._aacx._aad7._aade"));
            List<string> comments = new List<string>();
            foreach (var commentElement in commentElements)
            {
                comments.Add(commentElement.Text);
                CmtDaCao++;
                if (SoCmtRadio.IsChecked == true)
                    if (CmtDaCao >= (int.Parse)(SoCmtTbx.Text))
                    {
                        stop = 1;
                        break;
                    }
            }
            string filePath = saveFolderPath + "\\CmtOfPost_" + PostIndex + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < comments.Count; i++)
            {
                sw.WriteLine(comments[i]);
            }
            sw.Flush();
            sw.Close();
        }
        //Loading comments
        public void LoadCmts(ref int CmtDaLoad)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)CD;
            try
            {
                Actions actions = new Actions(CD);
                WebDriverWait wait = new WebDriverWait(CD, TimeSpan.FromSeconds(6));

                while (true)
                {
                    Thread.Sleep(1000);
                    actions.SendKeys(OpenQA.Selenium.Keys.End).Perform();
                    Thread.Sleep(2500);
                    IWebElement loadButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("svg[aria-label='Load more comments']")));
                    loadButton.Click();
                    CmtDaLoad = CmtDaLoad + 14;
                    if (SoCmtRadio.IsChecked == true)
                        if (CmtDaLoad >= (int.Parse)(SoCmtTbx.Text))
                            break;
                }
            }
            catch (WebDriverTimeoutException)
            {
                long currentHeight = (long)js.ExecuteScript("return Math.max( document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight );");
                WebDriverWait wait = new WebDriverWait(CD, TimeSpan.FromSeconds(6));
                long newHeight = (long)js.ExecuteScript("return Math.max( document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight );");

                if (newHeight == currentHeight)
                {
                    return;
                }

                By lastImageLocator = By.CssSelector("div._aagw:last-child");
                wait.Until(ExpectedConditions.ElementIsVisible(lastImageLocator));
            }
        }
        //Crawl Img mỗi post
        public void ImgEachPost(ref int AnhDaCao, ref int stop)
        {
            IWebElement nextImgButton = null;
            int ImageCount = 1;
            List<string> ListURLImg = new List<string>();
            int IsOnly1=0;
            while (true)
            {
                if (this.SoAnhRadio.IsChecked == true)
                {
                    if (stop == 1)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(1000);
                }

                if (ImageCount == 1)
                {
                    try
                    {
                        nextImgButton = CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe.x1qjc9v5.xjbqb8w.x1lcm9me.x1yr5g0i.xrt01vj.x10y3i5r.xr1yuqi.xkrivgy.x4ii5y1.x1gryazu.x15h9jz8.x47corl.xh8yej3.xir0mxb.x1juhsu6 > div > article > div > div._aatk._aatl > div > div._aamn > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x10l6tqk.x1ey2m1c.x13vifvy.x17qophe.xds687c.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1 > div > button"));
                    }
                    catch
                    {
                        IsOnly1 = 1;
                        break;
                    }
                }
                else
                {
                    try
                    {
                        nextImgButton = CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe.x1qjc9v5.xjbqb8w.x1lcm9me.x1yr5g0i.xrt01vj.x10y3i5r.xr1yuqi.xkrivgy.x4ii5y1.x1gryazu.x15h9jz8.x47corl.xh8yej3.xir0mxb.x1juhsu6 > div > article > div > div._aatk._aatl > div > div._aamn > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x10l6tqk.x1ey2m1c.x13vifvy.x17qophe.xds687c.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1 > div > button._afxw._al46._al47"));
                        nextImgButton.Click();
                        nextImgButton.Click();
                    }
                    catch { nextImgButton = null; }
                }

                string imageUrl;
                IList<IWebElement> imageElements = CD.FindElements(By.XPath("//div[@role='dialog']//article[@role='presentation']//li[@class='_acaz']//div[@role='button']//div[@class='_aagv']//img"));
                for (int i = 0; i < imageElements.Count(); i++)
                {
                    imageUrl = imageElements[i].GetAttribute("src");
                    if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram"))
                    {
                        int flag = 1;
                        for (int j = 0; j < ListURLImg.Count(); j++)
                        {
                            if (imageUrl == ListURLImg[j])
                                flag = 0;
                        }
                        if (flag == 1)
                        {
                            ListURLImg.Add(imageUrl);
                            FileDownloader downloader = new FileDownloader();
                            string fileName = System.IO.Path.GetFileName("image" + AnhDaCao + ".jpg");
                            string imagePath = System.IO.Path.Combine(saveFolderPath, fileName);
                            downloader.DownloadFile(imageUrl, imagePath);
                            AnhDaCao++;
                            if (this.SoAnhRadio.IsChecked == true)
                            {
                                if (AnhDaCao > (int.Parse(this.SoAnhTbx.Text)) - 1)
                                {
                                    stop = 1;
                                    break;

                                }
                                System.Threading.Thread.Sleep(1000);
                            }
                        }
                        ImageCount++;

                    }
                }

                if (nextImgButton != null)
                {
                    try
                    {
                        nextImgButton.Click();
                    }
                    catch { }
                }
                else
                    break;
            }
            if(IsOnly1==1)
            {
                string imageUrl;
                IWebElement imageElement ;
                try
                {
                    imageElement = CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe.x1qjc9v5.xjbqb8w.x1lcm9me.x1yr5g0i.xrt01vj.x10y3i5r.xr1yuqi.xkrivgy.x4ii5y1.x1gryazu.x15h9jz8.x47corl.xh8yej3.xir0mxb.x1juhsu6 > div > article > div > div._aatk._aatl._aatm > div > div > div > div._aagv > img"));
                }
                catch
                {
                    try
                    {
                        imageElement = CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe.x1qjc9v5.xjbqb8w.x1lcm9me.x1yr5g0i.xrt01vj.x10y3i5r.xr1yuqi.xkrivgy.x4ii5y1.x1gryazu.x15h9jz8.x47corl.xh8yej3.xir0mxb.x1juhsu6 > div > article > div > div._aatk._aatl > div > div > div > div._aagv > img"));
                    }
                    catch
                    {
                        imageElement = CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe.x1qjc9v5.xjbqb8w.x1lcm9me.x1yr5g0i.xrt01vj.x10y3i5r.xr1yuqi.xkrivgy.x4ii5y1.x1gryazu.x15h9jz8.x47corl.xh8yej3.xir0mxb.x1juhsu6 > div > article > div > div._aatk._aatl > div > div > div > div._aagu._aa20._aato > div._aagv > img"));
                    }
                }
                imageUrl = imageElement.GetAttribute("src");
                FileDownloader downloader = new FileDownloader();
                string fileName = System.IO.Path.GetFileName("image" + AnhDaCao + ".jpg");
                string imagePath = System.IO.Path.Combine(saveFolderPath, fileName);
                downloader.DownloadFile(imageUrl, imagePath);
                AnhDaCao++;
                if (this.SoAnhRadio.IsChecked == true)
                {
                    if (AnhDaCao > (int.Parse(this.SoAnhTbx.Text)) - 1)
                    {
                        stop = 1;
                    }
                    System.Threading.Thread.Sleep(1000);
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
        private void Cao_Anh_Checked(object sender, RoutedEventArgs e)
        {
            this.TatCaAnh.IsEnabled = true;
            this.SoAnhRadio.IsEnabled = true;
            if (this.SoAnhRadio.IsChecked == true)
                this.SoAnhTbx.IsEnabled = true;
        }

        private void Cao_BL_Checked(object sender, RoutedEventArgs e)
        {
            this.TatCaCmt.IsEnabled = true;
            this.SoCmtRadio.IsEnabled = true;
            if (this.SoCmtRadio.IsChecked == true)
                this.SoCmtTbx.IsEnabled = true;
        }

        private void Cao_Anh_Unchecked(object sender, RoutedEventArgs e)
        {
            this.TatCaAnh.IsEnabled = false;
            this.SoAnhRadio.IsEnabled = false;
            this.SoAnhTbx.Text = string.Empty;
            this.SoAnhTbx.IsEnabled = false;

        }

        private void Cao_BL_Unchecked(object sender, RoutedEventArgs e)
        {
            this.TatCaCmt.IsEnabled = false;
            this.SoCmtRadio.IsEnabled = false;
            this.SoCmtTbx.Text = string.Empty;
            this.SoCmtTbx.IsEnabled = false;
        }

        private void SoAnhRadio_Checked(object sender, RoutedEventArgs e)
        {
            this.SoAnhTbx.IsEnabled = true;
        }

        private void SoCmtRadio_Checked(object sender, RoutedEventArgs e)
        {
            this.SoCmtTbx.IsEnabled = true;
        }

        private void SoAnhRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            this.SoAnhTbx.IsEnabled = false;
            this.SoAnhTbx.Text = string.Empty;
        }

        private void SoCmtRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            this.SoCmtTbx.IsEnabled = false;
            this.SoCmtTbx.Text = string.Empty;
        }
    }
}