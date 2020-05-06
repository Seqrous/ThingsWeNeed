using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop.Pages.Household
{
    /// <summary>
    /// Interaction logic for HouseholdCreatePage.xaml
    /// </summary>
    public partial class HouseholdCreatePage : Page
    {
        HouseholdRest householdRest;
        MainWindow mainWindow;

        public HouseholdCreatePage(MainWindow mainWindow)
        {
            if (householdRest == null)
            {
                householdRest = new HouseholdRest();
            }

            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHouseholdPage();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name is required.");
            }
            else
            {
                AddressDto addressDto = new AddressDto()
                {
                    Address1 = address1TextBox.Text,
                    Address2 = address2TextBox.Text,
                    City = cityTextBox.Text,
                    Country = countryTextBox.Text,
                    PostCode = postCodeTextBox.Text,
                };

                HouseholdDto household = new HouseholdDto()
                {
                    Name = nameTextBox.Text,
                    Address = addressDto,
                };

                householdRest.Create(household);
            }
        }
    }
}
