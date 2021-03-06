﻿using LogicLayer;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Interface
{
    /// <summary>
    /// Logika interakcji dla klasy ConnectionSettings.xaml
    /// </summary>
    public partial class ConnectionSettings : Page
    {
        public ConnectionSettings()
        {
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            string portName = box.SelectedItem?.ToString().Substring(38);
            int baudRate;
            bool success = int.TryParse(baud.Text, out baudRate);
            if(!success)
            {
                MessageBox.Show("Podany Baud Rate nie jest liczbą");
            }
            else if(portName!=null)
            {
                try
                {
                    Serial.GetInstance(portName, baudRate);
                    var actionMenu = new ActionMenu();
                    NavigationService.Navigate(actionMenu);
                }
                catch (NoDeviceException ex)
                {
                    MessageBox.Show(ex.FullMessage);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano portu");
            }
        }
    }
}
