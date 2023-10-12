using System;
using System.Collections.Generic;
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
using System.Net.Http;
using System.Drawing;
using System.Threading;
using JingHaiApp;
using JingHaiApp.Pages;
using Newtonsoft.Json;

namespace JingHaiApp.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            InitUI();
            InitTimeUI();
        }
        private void InitUI()
        {
            // UNIT 初始化欢迎标题 UI
            var WelcomeText = (Label)FindName("WelcomeText");
            var TitleName = (Label)FindName("TitleName");
            int currentHour = DateTime.Now.Hour;
            if (currentHour >= 0 && currentHour < 6) { WelcomeText.Content = "你好，"; TitleName.Margin = new Thickness(158,25,0,495); }
            if (currentHour >= 6 && currentHour < 8) { WelcomeText.Content = "早上好，"; TitleName.Margin = new Thickness(203,25,0,495); }
            if (currentHour >= 8 && currentHour < 12) { WelcomeText.Content = "上午好，"; TitleName.Margin = new Thickness(203,25,0,495); }
            if (currentHour >= 12 && currentHour < 14) { WelcomeText.Content = "中午好，"; TitleName.Margin = new Thickness(203,25,0,495); }
            if (currentHour >= 14 && currentHour < 18) { WelcomeText.Content = "下午好，"; TitleName.Margin = new Thickness(203,25,0,495); }
            if (currentHour >= 18 && currentHour < 24) { WelcomeText.Content = "晚上好，"; TitleName.Margin = new Thickness(203,25,0,495); }
            // UNIT 初始化用户名 + 身份组 UI
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            var UserName = mainWindow.GetUserName();
            var Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("-Type-Of-Client", "JingHai");
            var response = Client.GetAsync("http://127.0.0.1:3869/api/account/GetInfo?name="+UserName).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentstring = response.Content.ReadAsStringAsync().Result;
                List<string> content = JsonConvert.DeserializeObject<List<string>>(contentstring);
                var name = content[0];
                var level = content[2];
                TitleName.Content = name.Replace("_", "_ ");
                var Card1 = (Border)FindName("Card1");
                var Card1Text1 = (Label)FindName("Card1Text1");
                var Card1Text2 = (Label)FindName("Card1Text2");
                var Card2 = (Border)FindName("Card2");
                var Card2Text1 = (Label)FindName("Card2Text1");
                var Card2Text2 = (Label)FindName("Card2Text2");
                var Card3 = (Border)FindName("Card3");
                var Card3Text1 = (Label)FindName("Card3Text1");
                var Card3Text2 = (Label)FindName("Card3Text2");
                var Card3Text3 = (Label)FindName("Card3Text3");
                var Card3Text4 = (Label)FindName("Card3Text4");
                if (level == "1") 
                { 
                    Card1.Background = new SolidColorBrush(Color.FromArgb(255,3,114,62));
                    Card1Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card1Text2.Content = "待审核玩家";
                    Card1Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2.Background = new SolidColorBrush(Color.FromArgb(255,252,141,193));
                    Card2Text1.Foreground = new SolidColorBrush(Colors.Black);
                    Card2Text2.Foreground = new SolidColorBrush(Colors.Black);
                    Card3.Background = new SolidColorBrush(Color.FromArgb(255,46,53,198));
                    Card3Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text2.Content = "进行自助预审核（点击左侧第 2 个按钮）";
                    Card3Text3.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text3.Content = "没错，你现在只能干这件事 ...";
                    Card3Text3.FontSize = 13;
                    Card3Text4.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                }
                if (level == "2") 
                { 
                    Card1.Background = new SolidColorBrush(Color.FromArgb(255,0,72,255));
                    Card1Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card1Text2.Content = "工会成员";
                    Card1Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2.Background = new SolidColorBrush(Color.FromArgb(255,255,183,0));
                    Card2Text1.Foreground = new SolidColorBrush(Colors.Black);
                    Card2Text2.Foreground = new SolidColorBrush(Colors.Black);
                    Card3.Background = new SolidColorBrush(Color.FromArgb(255,46,198,97));
                    Card3Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text2.Content = "查看工会成员列表";
                    Card3Text3.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text3.Content = "提交大型申请工单（点击左侧第 3 按钮）";
                    Card3Text4.Foreground = new SolidColorBrush(Colors.AntiqueWhite);                
                }
                if (level == "3") 
                { 
                    Card1.Background = new SolidColorBrush(Color.FromArgb(255,255,138,0));
                    Card1Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card1Text2.Content = "工会精英";
                    Card1Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2.Background = new SolidColorBrush(Color.FromArgb(255,0,117,255)); 
                    Card2Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3.Background = new SolidColorBrush(Color.FromArgb(255,76,198,46));
                    Card3Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text2.Content = "查看工会成员列表";
                    Card3Text3.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text3.Content = "提交大型申请工单（点击左侧第 3 按钮）";
                    Card3Text4.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3Text3.Content = "待定 ...";
                    Card3Text4.FontSize = 13;
                }
                if (level == "4") 
                { 
                    Card1.Background = new SolidColorBrush(Color.FromArgb(255,178,126,255));
                    Card1Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card1Text2.Content = "工会管理";
                    Card1Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2.Background = new SolidColorBrush(Color.FromArgb(255,77,129,0));
                    Card2Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3.Background = new SolidColorBrush(Color.FromArgb(255,50,212,217));
                    Card3Text1.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text2.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text2.Content = "查看 / 管理工会成员列表";
                    Card3Text3.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text3.Content = "提交大型申请工单（点击左侧第 3 按钮）";
                    Card3Text4.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text4.Content = "批准大型工单申请";
                }
                if (level == "5") 
                { 
                    Card1.Background = new SolidColorBrush(Color.FromArgb(255,255,63,50));
                    Card1Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card1Text2.Content = "工会会长";
                    Card1Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2.Background = new SolidColorBrush(Color.FromArgb(255,50,194,255));
                    Card2Text1.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card2Text2.Foreground = new SolidColorBrush(Colors.AntiqueWhite);
                    Card3.Background = new SolidColorBrush(Color.FromArgb(255,255,213,0));
                    Card3Text1.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text2.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text2.Content = "你啥都可以干！全部！";
                    Card3Text3.Foreground = new SolidColorBrush(Colors.Black);
                    Card3Text3.Content = "不然呢？你可是会长啊";
                    Card3Text3.FontSize = 13;
                    Card3Text4.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        public void InitTimeUI()
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            var UserName = mainWindow.GetUserName();
            var Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("-Type-Of-Client", "JingHai");
            var response2 = Client.GetAsync("http://127.0.0.1:3869/api/account/GetInfo?name=" + UserName).Result;
            var contentstring = response2.Content.ReadAsStringAsync().Result;
            List<string> content = JsonConvert.DeserializeObject<List<string>>(contentstring);
            if (content != null)
            {
                var regy = content[3].ToString().Substring(0, 4);
                var regmo = content[3].ToString().Substring(4, 2);
                var regd = content[3].ToString().Substring(6, 2);
                var regh = content[3].ToString().Substring(8, 2);
                var regmi = content[3].ToString().Substring(10, 2);
                var realy = DateTime.Now.ToString("yyyy");
                var realmo = DateTime.Now.ToString("MM");
                var reald = DateTime.Now.ToString("dd");
                var realh = DateTime.Now.ToString("HH");
                var realmi = DateTime.Now.ToString("mm");
                var dvy = Math.Abs(int.Parse(realy) - int.Parse(regy));
                var dvmo = Math.Abs(int.Parse(realmo) - int.Parse(regmo));
                var dvd = Math.Abs(int.Parse(reald) - int.Parse(regd));
                var dvh = Math.Abs(int.Parse(realh) - int.Parse(regh));
                var dvmi = Math.Abs(int.Parse(realmi) - int.Parse(regmi));
                var Card2Text2 = (Label)FindName("Card2Text2");
                Card2Text2.Content = dvy.ToString() + "年" + dvmo.ToString() + "月" + dvd.ToString() + "日" + dvh.ToString() + "时" + dvmi.ToString() + "分";
            }
        }
    }
}
