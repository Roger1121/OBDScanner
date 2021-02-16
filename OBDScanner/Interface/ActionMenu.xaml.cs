using LogicLayer;
using System.Windows;
using System.Windows.Controls;

namespace Interface
{
    /// <summary>
    /// Logika interakcji dla klasy ActionMenu.xaml
    /// </summary>
    public partial class ActionMenu : Page
    {
        public ActionMenu()
        {
            InitializeComponent();
        }

        private void ShowCurrentData(object sender, RoutedEventArgs e)
        {
            var currentData = new CurrentData();
            NavigationService.Navigate(currentData);
        }

        private void ShowFreezeFrameData(object sender, RoutedEventArgs e)
        {
            var freezeFrame = new FreezeFrame();
            NavigationService.Navigate(freezeFrame);
        }

        private void ReadDTCs(object sender, RoutedEventArgs e)
        {
            var dTCs = new DTCs();
            NavigationService.Navigate(dTCs);
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Serial.GetInstance().CloseSerial();
            Application.Current.Shutdown();
        }
    }
}
