using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.RestInterface.Rest;

namespace Desktop.Pages.User
{
    /// <summary>
    /// Interaction logic for UserUpdatePage.xaml
    /// </summary>
    public partial class UserUpdatePage : Page
    {
        UserRest userRest;
        MainWindow mainWindow;
        UserDto currentUser;

        public UserUpdatePage(MainWindow mainWindow)
        {
            if (userRest == null)
            {
                userRest = new UserRest();
            }

            InitializeComponent();
            this.mainWindow = mainWindow;

            currentUser = userRest.Get(mainWindow.currentId);
            usernameTextBox.Text = currentUser.Username;
            emailTextBox.Text = currentUser.Email;
            phoneNumberTextBox.Text = currentUser.PhoneNumber;
            firstNameTextBox.Text = currentUser.FName;
            lastNameTextBox.Text = currentUser.LName;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserPage();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == null || emailTextBox.Text == null)
            {
                MessageBox.Show("Username and Email are required.");
            }
            else
            {
                UserDto user = new UserDto()
                {
                    Username = usernameTextBox.Text,
                    Email = emailTextBox.Text,
                    FName = firstNameTextBox.Text,
                    LName = lastNameTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text,
                };

                userRest.Update(user);
            }
        }
    }
}
