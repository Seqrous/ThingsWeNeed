using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;
using ThingsWeNeed.Shared.RestInterface.Rest;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        ClientUserManager userManager;
        UserRest userRest;
        MainWindow mainWindow;

        public UserPage(MainWindow userWindow)
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
            List<ThingDto> users = new List<ThingDto>();
            fillUsersList();
            this.mainWindow = userWindow;

            currentUsernameTextBlock.Text = "Current user: " + userManager.Get().Result.Username;
        }
        private  void fillUsersList()
        {
            ICollection<UserDto> users = userRest.GetCollection();
            myDataGrid.ItemsSource = users;
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserCreatePage();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDto user = (UserDto)myDataGrid.SelectedItem;
            mainWindow.GoToUserUpdatePage(user.Id);
        }

        private void householdBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void usersNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserPage();
        }

        private void householdsNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHouseholdPage();
        }

        private void thingsNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingPage();
        }

        private async void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            await userManager.LogOff();

            if (userManager.LogOff().IsCompleted)
            {
                mainWindow.GoToLoginPage();
            }
        }
    }
}
