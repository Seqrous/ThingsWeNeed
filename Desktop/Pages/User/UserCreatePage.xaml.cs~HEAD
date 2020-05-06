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

            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserPage();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == null || emailTextBox.Text == null || passwordTextBox.Password == null || confirmPasswordTextBox == null)
            {
                MessageBox.Show("Username, Email and Password are required.");
            }
            else
            {
                RegisterBinder userRegister = new RegisterBinder()
                {
                    Email = emailTextBox.Text,
                    FName = firstNameTextBox.Text,
                    LName = lastNameTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text,
                    Username = usernameTextBox.Text,
                    Password = passwordTextBox.Password,
                    ConfirmPassword = confirmPasswordTextBox.Password,
                };

                userManager.Register(userRegister);
            }
        }
    }
}
