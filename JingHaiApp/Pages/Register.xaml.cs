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
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var usernameInput = FindName("usernameInput") as TextBox;
            var username = usernameInput.Text;
            var passwordInput = FindName("passwordInput") as TextBox;
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
                    var response = client.GetAsync("http://127.0.0.1:3869/api/account/Register?name="+username+"&pwd="+pwd).Result;
                    var statuscode = response.StatusCode;
                    if (statuscode.ToString() == "218")
                    {
                        MessageBox.Show("注册成功，请登录", "提示");
                    }
                    if (statuscode.ToString() == "Unauthorized")
                    {
                        MessageBox.Show("注册失败", "提示");
                    }
                    if (statuscode.ToString() == "217")
                    {
                        MessageBox.Show("用户已存在，请直接登录", "提示");
                    }
                    // MessageBox.Show(statuscode.ToString(),"返回值");
                }
            }
            catch
            {
                MessageBox.Show("无法连接至服务器：本地错误","错误");
            }
        }

        private void GotoLogin_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GotoLogin();
        }
    }
}
