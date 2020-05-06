using Desktop.Pages;
using Desktop.Pages.Household;
using Desktop.Pages.User;
using System.Windows;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentId;
        public string currentUserId;
        public ClientUserManager manager;

        public MainWindow()
        {
            RestClient.SetDomain("https://localhost:44371");

            manager = new ClientUserManager();
            
            InitializeComponent();
            GoToLoginPage();
        }

        public void GoToLoginPage()
        {
            LoginPage newPage = new LoginPage(this);
            Content = newPage;
        }

        public void GoToThingPage()
        {
            ThingPage newPage = new ThingPage(this);
            Content = newPage;
        }

        public void GoToThingUpdatePage(int id)
        {
            currentId = id;
            ThingUpdatePage newPage = new ThingUpdatePage(this);
            Content = newPage;
        }

        public void GoToThingCreatePage()
        {
            ThingCreatePage newPage = new ThingCreatePage(this);
            Content = newPage;
        }

        public void GoToHouseholdPage()
        {
            HouseholdPage newPage = new HouseholdPage(this);
            Content = newPage;
        }

        public void GoToHouseholdUpdatePage(int id)
        {
            currentId = id;
            HouseholdUpdatePage newPage = new HouseholdUpdatePage(this);
            Content = newPage;
        }

        public void GoToHouseholdCreatePage()
        {
            HouseholdCreatePage newPage = new HouseholdCreatePage(this);
            Content = newPage;
        }

        public void GoToUserPage()
        {
            UserPage newPage = new UserPage(this);
            Content = newPage;
        }

        public void GoToUserCreatePage()
        {
            UserCreatePage newPage = new UserCreatePage(this);
            Content = newPage;
        }

        public void GoToUserUpdatePage(string id)
        {
            currentUserId = id;
            UserUpdatePage newPage = new UserUpdatePage(this);
            Content = newPage;
        }
    }
}
