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


namespace JingHaiApp.Pages
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var usernameInput = (TextBox)FindName("usernameInput");
            var username = usernameInput.Text;
            var passwordInput = (TextBox)FindName("passwordInput");
            var pwd  = passwordInput.Text;
            client.DefaultRequestHeaders.Add("-Type-Of-Client", "JingHai");
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("用户名或密码不能为空", "提示");
                }
                else
                {
                    var response = client.GetAsync("http://127.0.0.1:3869/api/account/Login?name="+username+"&pwd="+pwd).Result;
                    var statuscode = response.StatusCode;
                    if (statuscode.ToString() == "217")
                    {
                        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.LoginSetup();
                        mainWindow.SetUserName(username);
                    }
                    if (statuscode.ToString() == "Forbidden")
                    {
                        MessageBox.Show("用户名或密码错误", "提示");
                    }
                    if (statuscode.ToString() == "Unauthorized")
                    {
                        MessageBox.Show("用户不存在，请先注册", "提示");
                    }
                }
            }
            catch
            {
                MessageBox.Show("无法连接至服务器：本地错误","错误");
            }
        }
        private void GotoRegistPage(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GotoRegister();
        }
    }
}
