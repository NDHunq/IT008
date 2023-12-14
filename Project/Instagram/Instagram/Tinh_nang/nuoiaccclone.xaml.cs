using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FlaUI.Core.WindowsAPI;
using Instagram.Tinh_nang.form;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Keyboard = FlaUI.Core.Input.Keyboard;
using FlaUI.Core.WindowsAPI;
using OpenQA.Selenium.Support.UI;

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for nuoiaccclone.xaml
    /// </summary>
    public partial class nuoiaccclone : UserControl
    {
        private List<string> _filenamepath = new List<string>();
        private int PostTimeCount = 0;
        public string Username;
        public string Password;
        int itd = 0;

        public nuoiaccclone()
        {
            InitializeComponent();
         

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
            
            
            nv.Children.Add(border);
          
           

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            try
            {
                Login(chromeDriver);
                if(new_usr1_Copy1.Text=="start")
                {
                    new_usr1_Copy1.Text = "stop";
                    btn_Copy2.Background= new SolidColorBrush(Colors.Red);
                }   
                else
                {
                    new_usr1_Copy1.Text = "start";
                    btn_Copy2.Background = new SolidColorBrush(Colors.Green);
                }

                foreach (Border Item in nv.Children)
                {
                    Label label = Item.Child as Label;
                    if (label.Content.ToString().Contains("Comment"))
                    {
                        Comment(chromeDriver);
                    
                    }
                    if (label.Content.ToString().Contains("Tim"))
                    {
                        Tym(chromeDriver);
                    
                    }
                    if (label.Content.ToString().Contains("Đăng bài ngẫu nhiên"))
                    {
                        Post(chromeDriver);
                    }
                }
                PostTimeCount = 0;
                chromeDriver.Quit();
                
            }
            catch (Exception exception)
            {
                chromeDriver.Quit();
                MessageBox.Show(exception.Message);
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
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
                if (PostTimeCount == 0)
                {
                    CD.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div/div/div/div/div[2]/div/div/div[3]/button[2]")).Click();
                    Thread.Sleep(300);
                }
                IWebElement newPostButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='New post']")));
                newPostButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Select from computer']"))).Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Keyboard.Type(_filenamepath[0]);

                Thread.Sleep(TimeSpan.FromSeconds(1));
                Keyboard.Press(VirtualKeyShort.ENTER);
                Thread.Sleep(TimeSpan.FromSeconds(1));


                CD.FindElement(By.XPath("//*[@aria-label='Open media gallery']")).Click();
                for (int i = 1; i < _filenamepath.Count(); i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    CD.FindElement(By.XPath("//*[@class='x9f619 xjbqb8w x78zum5 x168nmei x13lgxp2 x5pf9jr xo71vjh x1n2onr6 x1plvlek xryxfnj x1iyjqo2 x2lwn1j xeuugli xdt5ytf xqjyukv x1qjc9v5 x1oa3qoh x1nhvcw1']")).Click();



                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@aria-label='Plus icon']"))).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Keyboard.Type(_filenamepath[i]);

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Keyboard.Press(VirtualKeyShort.ENTER);
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[9]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"))).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[9]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"))).Click();
                
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[9]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[2]/div/div[1]/div[1]/p"))).SendKeys(getRandomDescription()+"  #"+getRandomHashtag()+" ");

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[9]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div[5]/div/span[2]"))).Click();
              
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[9]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"))).Click();
                PostTimeCount++;
                Thread.Sleep(TimeSpan.FromSeconds(15));
            }
            catch (Exception e)
            {
                CD.Quit();
                MessageBox.Show("Đã đăng bài thất bại");
            }
                
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

                    ScrollTo(driver);
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div[1]/div/div[6]/div[2]/div/a/div/div[2]")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                
                    //Tym
                    IWebElement likeButton = driver.FindElement(By.CssSelector("span._aamw svg[aria-label='Like']"));
                    likeButton.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
                catch (Exception e)
                {
                    driver.Quit();
                    MessageBox.Show("Đã tym thất bại");
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

                ScrollTo(driver);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div[1]/div/div[6]/div[2]/div/a/div/div[2]")).Click();
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

            int index = random.Next(0, listComment.Count);
            return listComment[index];
        }
        
        private void ScrollTo(ChromeDriver driver)
        {
            // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            Random rand = new Random();
            int x = rand.Next(0, 1000);
            int y = rand.Next(0, 1000);

            js.ExecuteScript("window.scrollTo(" + x + ", " + y + ");");
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

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Label clickedItem = FindClickedItem(sender);
            var parentBorder = VisualTreeHelper.GetParent(clickedItem) as Border;

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
