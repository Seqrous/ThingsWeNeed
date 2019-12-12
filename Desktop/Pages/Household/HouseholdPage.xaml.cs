﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace Desktop.Pages
{
    /// <summary>
    /// Interaction logic for HouseholdPage.xaml
    /// </summary>
    public partial class HouseholdPage : Page
    {
        HouseholdRest householdRest;
        MainWindow mainWindow;

        public HouseholdPage(MainWindow householdWindow)
        {
            if (householdRest == null)
            {
                householdRest = new HouseholdRest();
            }

            InitializeComponent();
            List<HouseholdDto> households = new List<HouseholdDto>();
            fillHouseholdsList();
            this.mainWindow = householdWindow;
        }

        private void fillHouseholdsList()
        {
            ICollection<HouseholdDto> households = householdRest.GetCollection();
            myDataGrid.ItemsSource = households;
        }

        private void thingsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usersBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            HouseholdDto household = (HouseholdDto)myDataGrid.SelectedItem;
            mainWindow.GoToHouseholdUpdatePage(household.HouseholdId);
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHouseholdCreatePage();
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
    }
}
