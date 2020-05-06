using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for ThingPage.xaml
    /// </summary>
    public partial class ThingPage : Page
    {
        ThingRest thingRest;
        MainWindow mainWindow;

        public ThingPage(MainWindow thingWindow)
        {
            if(thingRest == null)
            {
                thingRest = new ThingRest();
            }

            InitializeComponent();
            List<ThingDto> things = new List<ThingDto>();
            fillThingsList();
            this.mainWindow = thingWindow;
        }

        private void fillThingsList()
        {
            ICollection<ThingDto> things = thingRest.GetCollection();
            myDataGrid.ItemsSource = things;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ThingDto thing = (ThingDto)myDataGrid.SelectedItem;
            thingRest.Delete(thing.ThingId);
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            ThingDto thing = (ThingDto)myDataGrid.SelectedItem;
            mainWindow.GoToThingUpdatePage(thing.ThingId);
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingCreatePage();
        }

        private void thingsNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingPage();
        }

        private void householdsNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHouseholdPage();
        }

        private void usersNavBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserPage();
        }
    }
}
