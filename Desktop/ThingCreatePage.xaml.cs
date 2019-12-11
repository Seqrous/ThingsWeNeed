﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for ThingCreatePage.xaml
    /// </summary>
    public partial class ThingCreatePage : Page
    {
        MainWindow mainWindow;

        public ThingCreatePage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToThingPage();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}