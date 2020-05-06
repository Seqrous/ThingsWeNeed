using System;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for ThingUpdatePage.xaml
    /// </summary>
    public partial class ThingUpdatePage : Page
    {
        ThingRest thingRest;
        MainWindow mainWindow;
        ThingDto currentThing;

        public ThingUpdatePage(MainWindow mainWindow)
        {
            if (thingRest == null)
            {
                thingRest = new ThingRest();
            }

            InitializeComponent();
            this.mainWindow = mainWindow;

            currentThing = thingRest.Get(mainWindow.currentId);
            nameTextBox.Text = currentThing.Name;
            defaultPriceTextBox.Text = currentThing.DefaultPrice.ToString();
            neededCheckBox.IsChecked = currentThing.Needed;
            householdIdTextBlock.Text = currentThing.HouseholdId.ToString();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingPage();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name is required.");
            }
            else
            {
                double defaultPrice = 0;

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
                    HouseholdId = currentThing.HouseholdId,
                    Needed = (bool)neededCheckBox.IsChecked,
                    DefaultPrice = defaultPrice,
                    Show = true,
                };

                thingRest.Update(thing);
            }
        }
    }
}
