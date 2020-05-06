using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;
using ThingsWeNeed.Shared.RestInterface.Rest;

namespace Desktop.Pages.User
{
    /// <summary>
    /// Interaction logic for UserCreatePage.xaml
    /// </summary>
    public partial class UserCreatePage : Page
    {
        ClientUserManager userManager;
        UserRest userRest;
        MainWindow mainWindow;

        public UserCreatePage(MainWindow mainWindow)
        {
            if (userRest == null)
            {
                userRest = new UserRest();
            }

            if (userManager == null)
            {
                userManager = new ClientUserManager();
            }

            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RestClient.AuthToken != null)
            {
                mainWindow.GoToUserPage();
            }
            else
            {
                mainWindow.GoToLoginPage();
            }
        }

        private async void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == "" || emailTextBox.Text == "" || passwordTextBox.Password == "" || confirmPasswordTextBox.Password == "")
            {
                MessageBox.Show("Username, Email and Password are required.");
            }
            else
            {
                RegisterBinder registerBinder = new RegisterBinder()
                {
                    Email = emailTextBox.Text,
                    FName = firstNameTextBox.Text,
                    LName = lastNameTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text,
                    Username = usernameTextBox.Text,
                    Password = passwordTextBox.Password,
                    ConfirmPassword = confirmPasswordTextBox.Password,
                };

                await userManager.Register(registerBinder);

                if(userManager.Register(registerBinder) == null)
                {
                    mainWindow.GoToThingPage();
                }
            }
        }
    }
}
