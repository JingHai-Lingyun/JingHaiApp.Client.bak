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
using System.Drawing;
using JingHaiApp.Pages;

namespace JingHaiApp
{
    /// <summary>
    /// MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string LoginState = "False";
        public MainWindow()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new System.Uri("Pages/Login.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void RdHome_Click(object sender, RoutedEventArgs e)
        {
            if (LoginState == "True")
                PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
                HomePage homepage = new HomePage();
                homepage.InitTimeUI();
        }
        
        private void RdJoinTest_Click(object sender, RoutedEventArgs e)
        {
            if (LoginState == "True")
                PagesNavigation.Navigate(new System.Uri("Pages/JoinTest.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RdUserList_Click(object sender, RoutedEventArgs e)
        {
            if (LoginState == "True")
                PagesNavigation.Navigate(new System.Uri("Pages/Member.xaml", UriKind.RelativeOrAbsolute));
        }

        public void GotoLogin()
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Login.xaml", UriKind.RelativeOrAbsolute));
        }

        public void GotoRegister()
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Register.xaml", UriKind.RelativeOrAbsolute));
        }

        public void LoginSetup()
        {
            LoginState = "True";
            PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
            var radiobtn1 = (RadioButton)FindName("RdHome");
            var radiobtn2 = (RadioButton)FindName("RdUserList");
            radiobtn1.IsChecked = true;
            radiobtn2.IsChecked = false;
        }

        // 自定义移动事件
        private void MoveBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 当鼠标左键按下时，记录当前鼠标位置和窗口位置
            Mouse.Capture(sender as UIElement);
            var element = sender as FrameworkElement;
            var mainWindow = Window.GetWindow(element);
            var startPoint = e.GetPosition(mainWindow);

            // 绑定鼠标移动和释放事件
            element.MouseMove += (s, args) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    // 计算窗口新位置
                    var relativePosition = args.GetPosition(mainWindow);
                    var offsetX = relativePosition.X - startPoint.X;
                    var offsetY = relativePosition.Y - startPoint.Y;
                    var newLeft = mainWindow.Left + offsetX;
                    var newTop = mainWindow.Top + offsetY;

                    // 更新窗口位置
                    mainWindow.Left = newLeft;
                    mainWindow.Top = newTop;
                }
            };

            element.MouseLeftButtonUp += (s, args) =>
            {
                // 释放鼠标捕获
                Mouse.Capture(null);
            };
        }

        // 变量操作
        public string UserName;
        public void SetUserName(string name){ UserName = name; }
        public string GetUserName(){ return UserName; }
        public string UserLevel;
        public void SetUserLevel(string level){ UserLevel = level; }
        public string GetUserLevel(){ return UserLevel; }
    }   
}
