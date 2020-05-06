using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop.Pages.Household
{
    /// <summary>
    /// Interaction logic for HouseholdUpdatePage.xaml
    /// </summary>
    public partial class HouseholdUpdatePage : Page
    {
        HouseholdRest householdRest;
        MainWindow mainWindow;
        HouseholdDto currentHousehold;

        public HouseholdUpdatePage(MainWindow mainWindow)
        {
            if (householdRest == null)
            {
                householdRest = new HouseholdRest();
            }

            InitializeComponent();
            this.mainWindow = mainWindow;

            currentHousehold = householdRest.Get(mainWindow.currentId);
            nameTextBox.Text = currentHousehold.Name;
            address1TextBox.Text = currentHousehold.Address.Address1;
            address2TextBox.Text = currentHousehold.Address.Address2;
            cityTextBox.Text = currentHousehold.Address.City;
            postCodeTextBox.Text = currentHousehold.Address.PostCode;
            countryTextBox.Text = currentHousehold.Address.Country;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHouseholdPage();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
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

                householdRest.Update(household);
            }
        }
    }
}
