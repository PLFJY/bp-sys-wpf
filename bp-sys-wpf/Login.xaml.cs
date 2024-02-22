using Flurl.Http;
using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace bp_sys_wpf
{
    public class User
    {

        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string chinaname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool isadmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> roles { get; set; }
    }
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        private bool IsWindowOpen(string windowName)
        {
            return Application.Current.Windows.OfType<Window>().Any(window => window.Name == windowName);
        }
        private async void Verify()//登录验证
        {

            try
            {
                //发送HTTP登录请求
                var a = await "https://api.idvasg.cn/api/v1/login".PostJsonAsync(new { username = AccountBox.Text, password = PasswordBox.Password });

                string Token = await a.GetStringAsync();
                //保存token到文件
                File.WriteAllText("Token.txt", Token);
                var req = "https://api.idvasg.cn/api/v1/user".WithOAuthBearerToken(await a.GetStringAsync());
                var json = await req.GetJsonAsync<User>();
                if (json.isadmin)
                {
                    MessageBox.Show($"登录成功! 欢迎“{json.chinaname} ”使用BP系统", "Success");
                    if (!IsWindowOpen("MainWindow1"))
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        mainWindow.NowUser.Content = "当前用户:" + json.chinaname;
                    }
                    else
                    {
                        MainWindow.mainWindow.Activate();
                        MainWindow.mainWindow.NowUser.Content = "当前用户:" + json.chinaname;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录失败", "Failed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录失败,原因：{ex.Message}", "Failed");
            }
        }
        public string GetAbsoluteFilePath(string filePath)

        {
            // 获取应用程序的运行目录  
            string appDir = Environment.CurrentDirectory; // 在WPF中可以使用Environment.CurrentDirectory获取当前目录  
            // 拼接路径获取绝对路径  
            string absoluteFilePath = Path.Combine(appDir, filePath);
            return absoluteFilePath;

        }
        private async void TokenLogin()
        {
            string Token;
            Token = File.ReadAllText(GetAbsoluteFilePath("Token.txt"));
            try
            {
                var req = "https://api.idvasg.cn/api/v1/user".WithOAuthBearerToken(Token);
                var json = await req.GetJsonAsync<User>();
                if (json.isadmin)
                {
                    if (!IsWindowOpen("MainWindow1"))
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        mainWindow.NowUser.Content = "当前用户:" + json.chinaname;
                    }
                    else
                    {
                        MainWindow.mainWindow.Activate();
                        MainWindow.mainWindow.NowUser.Content = "当前用户:" + json.chinaname;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("权限不足", "Failed");
                }
            }
            catch { }
            
        }
        public Login()
        {
            InitializeComponent();
            if (File.Exists(GetAbsoluteFilePath("Token.txt"))){
                TokenLogin();
            }
            else
            {
                MessageBox.Show("Token已过期,请重新登录", "Failed");
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoginB_Click(object sender, RoutedEventArgs e)
        {
            if (AccountBox.Text == "admin" && PasswordBox.Password == "123456")//万一ASG官网炸了备用的
            {
                if (!IsWindowOpen("MainWindow1"))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    mainWindow.NowUser.Content = "当前用户:后门账户";
                }
                else
                {
                    MainWindow.mainWindow.Activate();
                    MainWindow.mainWindow.NowUser.Content = "当前用户:后门账户";
                }
                this.Close();
            }
            else
            {
                Verify();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)//在密码框回车即可登录
        {
            if (e.Key == Key.Enter)
            {
                if (AccountBox.Text == "admin" && PasswordBox.Password == "123456")//万一ASG官网炸了备用的
                {
                    if (!IsWindowOpen("MainWindow1"))
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        mainWindow.NowUser.Content = "当前用户:后门账户";
                    }
                    else
                    {
                        MainWindow.mainWindow.Activate();
                        MainWindow.mainWindow.NowUser.Content = "当前用户:后门账户";
                    }
                    this.Close();
                }
                else
                {
                    Verify();
                }
            }
        }
    }
}
