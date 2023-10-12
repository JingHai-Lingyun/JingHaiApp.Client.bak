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
using JingHaiApp;
using Newtonsoft.Json;

namespace JingHaiApp.Pages
{
    /// <summary>
    /// JoinTest.xaml 的交互逻辑
    /// </summary>
    public partial class JoinTest : Page
    {
        public JoinTest()
        {
            InitializeComponent();
            InitUI();
        }
        private void InitUI()
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            var UserName = mainWindow.GetUserName();
            if (UserName != "")
            {
                var Client = new HttpClient();
                Client.DefaultRequestHeaders.Add("-Type-Of-Client", "JingHai");
                var response = Client.GetAsync("http://127.0.0.1:3869/api/account/GetInfo?name="+UserName).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contentstring = response.Content.ReadAsStringAsync().Result;
                    List<string> content = JsonConvert.DeserializeObject<List<string>>(contentstring);
                    var level = content[2];
                    var name = content[0];
                    if (level == "1")
                    {
                        InitUI_NotMember(name);
                    }
                    else 
                    {
                        InitUI_isMember(name);
                    }
                }
            }
        }
        private void InitUI_NotMember(string name)
        {
            // 创建 Border 控件
            Border NotMember = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDC, 0x6C, 0x60)),
                CornerRadius = new CornerRadius(10),
                Width = 740,
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 85, 0, 0)
            };
            // 创建包含 Label 的 Grid 控件
            Grid grid = new Grid();
            // 创建第一个 Label
            Label label1 = new Label
            {
                Content = "你好 " + name.Replace("_","_ "),
                FontSize = 40,
                Foreground = new SolidColorBrush(Colors.AntiqueWhite),
                Width = 410,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(20.4, 0, 0, 0)
            };
            // 创建第二个 Label
            Label label2 = new Label
            {
                Content = "你还不是京海工会成员",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.AntiqueWhite),
                Width = 270,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, -40, 20.4, 0)
            };
            // 创建第三个 Label
            Label label3 = new Label
            {
                Content = "点击下方选项开始进行预审核",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.AntiqueWhite),
                Width = 270,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 40, 20.4, 0)
            };
            // 将 Label 添加到 Grid 中
            grid.Children.Add(label1);
            grid.Children.Add(label2);
            grid.Children.Add(label3);
            // 将 Grid 添加到 Border isMember 中
            NotMember.Child = grid;
            // 将 Border isMember 添加到 Container Grid 中
            Container.Children.Add(NotMember);
            // 创建选项
            InitUI_NotMemberChoose();
        }
        private void InitUI_NotMemberChoose()
        {
            // UNIT Card 1
            // 创建 Border 元素
            var border1 = new Border()
            {
                Width = 233,
                Height = 295,
                CornerRadius = new CornerRadius(10),
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(40, 0, 0, 0)
            };
            // 创建 StackPanel 元素
            var stackPanel1 = new StackPanel();
            // 向 StackPanel 添加子元素
            stackPanel1.Children.Add(new Image()
            {
                Width = 128,
                Height = 128,
                Source = new BitmapImage(new Uri("../Assets/Avatars/wooden_axe_128.png", UriKind.Relative)),
                Margin = new Thickness(52.5, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            });
            stackPanel1.Children.Add(new Label()
            {
                Content = "建筑",
                FontSize = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0)
            });
            Button btn1 = new Button()
            {
                Content = "点击开始",
                Width = 201,
                Height = 50,
                Margin = new Thickness(0, 20, 0, 0),
                Background = Brushes.Transparent,
                FontSize = 15,
                BorderThickness = new Thickness(0)
            };
            btn1.Click += (sender, e) => { StartJoinTest(1); };
            stackPanel1.Children.Add(btn1);
            // 将 StackPanel 添加到 Border
            border1.Child = stackPanel1;
            // 将 Border 添加到 Choose 网格
            Choose.Children.Add(border1);
            // UNIT Card 2
            // 创建 Border 元素
            var border2 = new Border()
            {
                Width = 233,
                Height = 295,
                CornerRadius = new CornerRadius(10),
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            // 创建 StackPanel 元素
            var stackPanel2 = new StackPanel();
            // 向 StackPanel 添加子元素
            stackPanel2.Children.Add(new Image()
            {
                Width = 128,
                Height = 128,
                Source = new BitmapImage(new Uri("../Assets/Avatars/redstone_128.png", UriKind.Relative)),
                Margin = new Thickness(52.5, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            });
            stackPanel2.Children.Add(new Label()
            {
                Content = "红石",
                FontSize = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0)
            });
            Button btn2 = new Button()
            {
                Content = "点击开始",
                Width = 201,
                Height = 50,
                Margin = new Thickness(0, 20, 0, 0),
                Background = Brushes.Transparent,
                FontSize = 15,
                BorderThickness = new Thickness(0)
            };
            btn2.Click += (sender, e) => { StartJoinTest(2); };
            stackPanel2.Children.Add(btn2);
            // 将 StackPanel 添加到 Border
            border2.Child = stackPanel2;
            // 将 Border 添加到 Choose 网格
            Choose.Children.Add(border2);
            // UNIT Card 3
            // 创建 Border 元素
            var border3 = new Border()
            {
                Width = 233,
                Height = 295,
                CornerRadius = new CornerRadius(10),
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 40, 0)
            };
            // 创建 StackPanel 元素
            var stackPanel3 = new StackPanel();
            // 向 StackPanel 添加子元素
            stackPanel3.Children.Add(new Image()
            {
                Width = 128,
                Height = 128,
                Source = new BitmapImage(new Uri("../Assets/Avatars/diamond_sword_128.png", UriKind.Relative)),
                Margin = new Thickness(52.5, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            });
            stackPanel3.Children.Add(new Label()
            {
                Content = "战斗",
                FontSize = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0)
            });
            Button btn3 = new Button()
            {
                Content = "点击开始",
                Width = 201,
                Height = 50,
                Margin = new Thickness(0, 20, 0, 0),
                Background = Brushes.Transparent,
                FontSize = 15,
                BorderThickness = new Thickness(0)
            };
            btn3.Click += (sender, e) => { StartJoinTest(3); };
            stackPanel3.Children.Add(btn3);
            // 将 StackPanel 添加到 Border
            border3.Child = stackPanel3;
            // 将 Border 添加到 Choose 网格
            Choose.Children.Add(border3);
        }
        //UNIT 预审核页面清空函数
        private void ClearPage()
        {
            Container.Children.Clear();
            Choose.Children.Clear();
        }
        //UNIT 预审核操作主函数
        private void StartJoinTest(int Type)
        {
            ClearPage(); //清空，准备重新布局
            if (Type == 1)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                UserName = mainWindow.GetUserName();
                var Client = new HttpClient();
                Client.DefaultRequestHeaders.Add("-Type-Of-Client", "JingHai");
                var response = Client.GetAsync("http://127.0.0.1:3869/api/jointest/newQATabel?name="+UserName).Result;
                if (response == "OK")
                {
                    
                }
            }
            if (Type == 2)
            {
                MessageBox.Show("2", "测试");
            }
            if (Type == 3)
            {
                MessageBox.Show("3", "测试");
            }
        }
        private void InitUI_isMember(string name)
        {
            // 创建 Border 控件
            Border isMember = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x7B, 0xC3, 0x6E)),
                CornerRadius = new CornerRadius(10),
                Width = 740,
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 85, 0, 0)
            };
            // 创建包含 Label 的 Grid 控件
            Grid grid = new Grid();
            // 创建第一个 Label
            Label label1 = new Label
            {
                Content = "恭喜 " + name,
                FontSize = 40,
                Foreground = new SolidColorBrush(Colors.AntiqueWhite),
                Width = 410,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(20.4, 0, 0, 0)
            };
            // 创建第二个 Label
            Label label2 = new Label
            {
                Content = "你已经成功的加入了京海工会",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.AntiqueWhite),
                Width = 270,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, -40, 20.4, 0)
            };
            // 创建第三个 Label
            Label label3 = new Label
            {
                Content = "你无需再次参加工会预审核",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.AntiqueWhite),
                Width = 270,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 40, 20.4, 0)
            };
            // 将 Label 添加到 Grid 中
            grid.Children.Add(label1);
            grid.Children.Add(label2);
            grid.Children.Add(label3);
            // 将 Grid 添加到 Border isMember 中
            isMember.Child = grid;
            // 将 Border isMember 添加到 Container Grid 中
            Container.Children.Add(isMember);
        }
    }
}
