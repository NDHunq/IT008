using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using FlaUI.Core.WindowsAPI;
using Instagram.Tinh_nang.form;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Keyboard = FlaUI.Core.Input.Keyboard;
using FlaUI.Core.WindowsAPI;
using OpenQA.Selenium.Support.UI;
using Timer = System.Timers.Timer;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for nuoiaccclone.xaml
    /// </summary>
    public partial class nuoiaccclone : UserControl
    {
        private List<string> _filenamepath = new List<string>();
        private bool PostTimeFirst;
        public string Username;
        public string Password;
        int itd = 0;

        private ChromeDriver chromeDriver;
        private DispatcherTimer t;

        
        List<Tinhnangnuoiclone> listtinhnang = new List<Tinhnangnuoiclone>();
        
        
        public nuoiaccclone()
        {
            InitializeComponent();
            
            
            t = new DispatcherTimer();
            t.Interval = TimeSpan.FromSeconds(1);
            t.Tick += HenGio;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            add_Description a=new add_Description("Thêm discription rác");
            a.ShowDialog();

          
            string txt = a.EnteredContent;
            

            Label labeledText = new Label
            {
               
                Content = txt,
                ContextMenu = (ContextMenu)Resources["contextMenuDescription"],

                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10)
            };
        
            Border border = new Border
            {
                BorderBrush = Brushes.Black,   // Màu của đường viền
                BorderThickness = new Thickness(2),  // Độ dày của đường viền
                Child = labeledText  // Đặt Label làm con của Border
            };
          // Thêm đối tượng TextBlock mới vào ScrollViewer
            if(a.isAccept == true)
                sd.Children.Add(border);
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
          
            

        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            add_Description a = new add_Description("Thêm comment rác");
            a.ShowDialog();


            string txt = a.EnteredContent;


            Label labeledText = new Label
            {
               
                Content = txt,
                ContextMenu = (ContextMenu)Resources["contextMenuComment"],

                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10)
            };
          
            Border border = new Border
            {
                BorderBrush = Brushes.Black,   // Màu của đường viền
                BorderThickness = new Thickness(2),  // Độ dày của đường viền
                Child = labeledText  // Đặt Label làm con của Border
            };
            // Thêm đối tượng TextBlock mới vào ScrollViewer
            if(a.isAccept == true)
                sc.Children.Add(border);

        }
        private void EditComment_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedItem = FindClickedItem(sender);
            if (clickedItem != null)
            {
                add_Description a = new add_Description("Thêm comment rác");
                a.ShowDialog();
                if (a.isAccept == false)
                {
                    a.Close();
                }
                else
                {
                    string txt = a.EnteredContent;
                    
                    clickedItem.Content = txt;
                }

                
            }
        }

        private void DeleteComment_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;

            sc.Children.Remove(parentBorder);
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                uri.Text = selectedFolder;
                var fileEntries = Directory.EnumerateFiles(selectedFolder);
                foreach (string fileName in fileEntries) 
                    _filenamepath.Add(fileName);
                // Sử dụng đường dẫn thư mục đã chọn ở đây
            }
        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            laplich a = new laplich();
            a.ShowDialog();
            string txt = a.EnteredContent;

           
            Label labeledText = new Label
            {
                Content = txt,
                ContextMenu = (ContextMenu)Resources["contextMenu"],
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10)
            };

            Border border = new Border
            {
                
                BorderBrush = Brushes.Black,   // Màu của đường viền
                BorderThickness = new Thickness(2),  // Độ dày của đường viền
                Child = labeledText  // Đặt Label làm con của Border
            };
            
            

            // Thêm đối tượng TextBlock mới vào ScrollViewer
            if (a.isAccept == true)
            {
                
                Tinhnangnuoiclone tinhnang = a.getTinhNang();
                listtinhnang.Add(tinhnang);
                
                nv.Children.Add(border);
            }
          
           

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            PostTimeFirst = true;
            chromeDriver = new ChromeDriver();
            Login(chromeDriver);
            t.Start();
            
        }
        

        private void HenGio(object sender, EventArgs e )
        {
            
            DateTime currentTime = DateTime.Now;
                        
            for (int i = 0; i < listtinhnang.Count; i++)
            {
                DateTime labelTime = getDateTimeFromString(listtinhnang[i].thoigian);
                if (currentTime >= labelTime )
                {
                    
                    if (listtinhnang[i].noidung.Contains("Comment")) //label.Content.ToString() = "Comment vào thời điểm: 12/12/2020 12:12:12"
                    {
                        if (!listtinhnang[i].hoanthanh)
                        {
                            OpenNewTab(chromeDriver);
                            Comment(chromeDriver);
                            listtinhnang[i].hoanthanh = true;
                        }
                        
                        
                    
                    }
                    if (listtinhnang[i].noidung.Contains("Tim"))
                    {
                        if (!listtinhnang[i].hoanthanh)
                        {
                            OpenNewTab(chromeDriver);
                            Tym(chromeDriver);
                            listtinhnang[i].hoanthanh = true;

                        }
                        
                        
                    
                    }
                    if (listtinhnang[i].noidung.Contains("Đăng bài ngẫu nhiên"))
                    {
                        if (!listtinhnang[i].hoanthanh)
                        {
                            OpenNewTab(chromeDriver);
                            Post(chromeDriver);
                            listtinhnang[i].hoanthanh = true;

                        }
                        
                    }

                    
                }

                if (listtinhnang[listtinhnang.Count - 1].hoanthanh)
                {
                    chromeDriver.Quit();
                    t.Stop();
                }
            }
            
            

        }            


        private DateTime getDateTimeFromString(string s)
        {
            
            //Comment ngẫu nhiên vào thời điểm: 12/12/2020 12:12:12;
            //Đăng bài ngẫu nhiên vào thời điểm: 12/12/2020 12:12:12;
            string a = s.Substring(s.Length- 19);
            
            DateTime dateTime = DateTime.Parse(a);
            
            
            
            return dateTime;
            
        }

        private void OpenNewTab(ChromeDriver driver)
        {
            try
            {
                driver.ExecuteScript("window.open('');");
                ReadOnlyCollection<string> tabs = driver.WindowHandles;
                driver.SwitchTo().Window(tabs[tabs.Count - 1]);
            }
            catch (Exception e)
            {
                MessageBox.Show("Đã mở tab mới thất bại");
            }
            
        }

        private void Login(ChromeDriver driver)
        {
            try
            {
                //chuyển tới trang 
                driver.Navigate().GoToUrl("https://www.instagram.com/");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                
                //Điền username và password
                driver.FindElement(By.XPath(
                        "/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[1]/div/label/input"))
                    .SendKeys(Username);
                driver.FindElement(By.XPath(
                        "/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[2]/div/label/input"))
                    .SendKeys(Password);
                Thread.Sleep(TimeSpan.FromSeconds(2));

                //Đăng nhập
                driver.FindElement(By.XPath(
                    "/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[3]/button/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
                
                if(driver.Url == "https://www.instagram.com/")
                    throw new Exception();
            }
            catch (Exception e)
            {
                driver.Quit();  
                t.Stop();
                MessageBox.Show("Đăng nhập thất bại");
            }
           
        }

        #region Post

        private void Post(ChromeDriver CD)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(CD, TimeSpan.FromSeconds(10));
                CD.Navigate().GoToUrl("https://www.instagram.com/");
                Thread.Sleep(300);
                if (PostTimeFirst)
                {
                    CD.FindElement(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div.x7r02ix.xf1ldfh.x131esax.xdajt7p.xxfnqb6.xb88tzc.xw2csxc.x1odjw0f.x5fp0pe > div > div > div._a9-z > button._a9--._ap36._a9_1")).Click();
                    Thread.Sleep(300);
                }
                IWebElement newPostButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='New post']")));
                newPostButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Select from computer']"))).Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                
                Random random = new Random();
                List<string> temp = new List<string>();

                // Random số lượng phần tử cần lấy
                int numberOfItems = random.Next(1, 10);  

                // Lặp qua số lượng đó
                for (int i = 0; i < numberOfItems; i++)
                {
                    // Random chỉ số phần tử
                    int index = random.Next(0, _filenamepath.Count);

                    // Lấy phần tử tại vị trí đó trong _filenamepath 
                    string path = _filenamepath[index];

                    // Thêm vào temp
                    temp.Add(path);
                }

                Keyboard.Type(temp[0]);
                // Keyboard.Type(_filenamepath[0]);

                
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Keyboard.Press(VirtualKeyShort.ENTER);
                Thread.Sleep(TimeSpan.FromSeconds(1));


                CD.FindElement(By.XPath("//*[@aria-label='Open media gallery']")).Click();
                for (int i = 1; i < temp.Count(); i++)
                // for (int i = 1; i < _filenamepath.Count; i++)

                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    CD.FindElement(By.XPath("//*[@class='x9f619 xjbqb8w x78zum5 x168nmei x13lgxp2 x5pf9jr xo71vjh x1n2onr6 x1plvlek xryxfnj x1iyjqo2 x2lwn1j xeuugli xdt5ytf xqjyukv x1qjc9v5 x1oa3qoh x1nhvcw1']")).Click();



                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='Plus icon']"))).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Keyboard.Type(temp[i]);
                    // Keyboard.Type(_filenamepath[i]);
                    
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Keyboard.Press(VirtualKeyShort.ENTER);
                }                                                                           
                Thread.Sleep(TimeSpan.FromSeconds(1));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div._ap97 > div > div > div > div._ac7b._ac7d > div > div"))).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div._ap97 > div > div > div > div._ac7b._ac7d > div > div"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div.x15wfb8v.x3aagtl.x6ql1ns.x78zum5.xdl72j9.x1iyjqo2.xs83m0k.x13vbajr.x1ue5u6n > div.xhk4uv.x26u7qi.xy80clv.x9f619.x78zum5.x1n2onr6.x1f4304s > div > div > div > div._ac2p > div:nth-child(2) > div > div.x6s0dn4.x78zum5.x1n2onr6.xh8yej3 > div.xw2csxc.x1odjw0f.x1n2onr6.x1hnll1o.xpqswwc.xl565be.x5dp1im.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x1w2wdq1.xen30ot.x1swvt13.x1pi30zi.xh8yej3.x5n08af.notranslate"))).SendKeys(getRandomDescription()+"  #"+getRandomHashtag()+" ");


                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.x1n2onr6.xzkaem6 > div.x9f619.x1n2onr6.x1ja2u2z > div > div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div._ap97 > div > div > div > div._ac7b._ac7d > div > div"))).Click();
                PostTimeFirst = false;
            }
            catch (Exception e)
            {
                //CD.Quit();
                MessageBox.Show("Đã đăng bài thất bại" + e.Message);
            }
                
        }
        
        private List<string> getRandomImagePathList()
        {
            
            // try
            // {
            //     Random random = new Random();
            //     int listCount = random.Next(1, _filenamepath.Count);
            //     List<string> temp = new List<string>();
            //
            //     for (int i = 0; i < listCount; i++)
            //     {
            //         int index = random.Next(0, _filenamepath.Count - 1);
            //         temp.Add(_filenamepath[index]);
            //     }
            //
            //     return temp;
            // }
            // catch (Exception e)
            // {
            //     return getRandomImagePathList();
            // }
            
            Random random = new Random();
            List<string> temp = new List<string>();

            // Random số lượng phần tử cần lấy
            int numberOfItems = random.Next(1, _filenamepath.Count);  

            // Lặp qua số lượng đó
            for (int i = 0; i < numberOfItems; i++)
            {
                // Random chỉ số phần tử
                int index = random.Next(0, _filenamepath.Count);

                // Lấy phần tử tại vị trí đó trong _filenamepath 
                string path = _filenamepath[index];
        
                // Thêm vào temp
                temp.Add(path);  
            }

            return temp;
            
        }
        private string getRandomHashtag()
        {
            
            string[] lines = HashTagBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            Random rand = new Random();
            int index = rand.Next(0, lines.Length);

            return lines[index]; 
            
        }
        private string getRandomDescription()
        {
            Random random = new Random();
            
            List<string> listComment = new List<string>();
            foreach (Border Item in sd.Children)
            {
                Label label = Item.Child as Label;
                listComment.Add(label.Content.ToString());
            }

            int index = random.Next(0, listComment.Count);
            return listComment[index];
        }

        #endregion
        
        
        #region Tym
            private void Tym(ChromeDriver driver)
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.instagram.com/explore/");
                    Thread.Sleep(TimeSpan.FromSeconds(3));

                    Random random = new Random();
                    int index = random.Next(0, 10);
                    driver.FindElements(By.ClassName("_aagw"))[index].Click();
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    
                    //Tym
                    IWebElement likeButton = driver.FindElement(By.CssSelector("span._aamw svg[aria-label='Like']"));
                    likeButton.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    
                    
                    
    
                }
                catch (Exception e)
                {
                    // driver.Quit();
                    MessageBox.Show("Đã tym thất bại ");
                }
                
                
            }
        

        #endregion
        
        

        #region Comment
        private void Comment(ChromeDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/explore/");
                Thread.Sleep(TimeSpan.FromSeconds(3));

                Random random = new Random();
                int index = random.Next(0, 10);
                driver.FindElements(By.ClassName("_aagw"))[index].Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                IWebElement textarea = driver.FindElement(By.TagName("textarea"));
                textarea.Click();
                textarea = driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys(GetRandomComment());
                Thread.Sleep(TimeSpan.FromSeconds(3));
                //Gửi cmt
                Actions actions = new Actions(driver);
                actions.SendKeys(Keys.Enter).Perform();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            catch (Exception e)
            {
                driver.Quit();
                MessageBox.Show("Đã comment thất bại");
            }
            
            
        }
        
        private string GetRandomComment()
        {
            Random random = new Random();
            
            List<string> listComment = new List<string>();
            foreach (Border Item in sc.Children)
            {
                Label label = Item.Child as Label;
                listComment.Add(label.Content.ToString());
            }

            int index = random.Next(0, listComment.Count - 1);
            return listComment[index];
        }
        
        private void ScrollTo(ChromeDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            
        }
        

        #endregion
        
        private static Label FindClickedItem(object sender)
        {
            var mi = sender as MenuItem;
            if (mi == null)
            {
                return null;
            }

            var cm = mi.CommandParameter as ContextMenu;
            if (cm == null)
            {
                return null;
            }

            return cm.PlacementTarget as Label;
        }
        
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedItem = FindClickedItem(sender);
            if (clickedItem != null)
            {
                laplich a = new laplich();
                a.ShowDialog();
                string txt = a.EnteredContent;
                clickedItem.Content = txt;
            }
        }

        // 0 1 2 3         
        
        
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;
            listtinhnang.RemoveAt(nv.Children.IndexOf(parentBorder));
            nv.Children.Remove(parentBorder);
        }
        
        private void EditDescription_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedItem = FindClickedItem(sender);
            if (clickedItem != null)
            {
                
            }
        }

        private void DeleteDescription_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;

            sd.Children.Remove(parentBorder);
        }
        
        
    }
}