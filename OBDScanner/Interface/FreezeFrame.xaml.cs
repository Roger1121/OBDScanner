using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Logika interakcji dla klasy FreezeFrame.xaml
    /// </summary>
    public partial class FreezeFrame : Page
    {
        public FreezeFrame()
        {
            InitializeComponent();
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            var actionMenu = new ActionMenu();
            NavigationService.Navigate(actionMenu);
        }
    }
}
