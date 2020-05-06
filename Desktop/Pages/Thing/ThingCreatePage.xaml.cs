using System;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for ThingCreatePage.xaml
    /// </summary>
    public partial class ThingCreatePage : Page
    {
        ThingRest thingRest;
        MainWindow mainWindow;

        public ThingCreatePage(MainWindow mainWindow)
        {
            if (thingRest == null)
            {
                thingRest = new ThingRest();
            }

            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingPage();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "" || householdIdTextBox.Text == "")
            {
                MessageBox.Show("Name and Household ID are required.");
            }
            else
            {
                int householdId = 0;
                double defaultPrice = 0;

                try
                {
                    householdId = Int32.Parse(householdIdTextBox.Text);
                }
                catch (FormatException a)
                {
                    MessageBox.Show("Household ID must be a number.");
                }

                if (defaultPriceTextBox.Text != "")
                {
                    try
                    {
                        defaultPrice = Double.Parse(defaultPriceTextBox.Text);
                    }
                    catch (FormatException a)
                    {
                        MessageBox.Show("Default Price must be a number.");
                    }
                }

                ThingDto thing = new ThingDto()
                {
                    Name = nameTextBox.Text,
                    HouseholdId = householdId,
                    Needed = (bool)neededCheckBox.IsChecked,
                    DefaultPrice = defaultPrice,
                    Show = true,
                };

                thingRest.Create(thing);
            }
        }
    }
}
