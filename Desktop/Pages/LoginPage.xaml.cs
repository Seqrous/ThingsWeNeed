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
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ClientUserManager userManager;
        MainWindow mainWindow;

        public LoginPage(MainWindow loginWindow)
        {
            if (userManager == null)
            {
                userManager = new ClientUserManager();
            }

            InitializeComponent();
            this.mainWindow = loginWindow;
        }

        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginBinder loginBinder = new LoginBinder()
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Password,
            };

            string[] errors = userManager.Login(loginBinder);

            if (errors.Length == 0) 
            {
                //Login successful
            } 
            else
            {
                //Login Failed
            }
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserCreatePage();
        }
    }
}
