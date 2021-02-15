using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Interface
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            var connectionSettings = new ConnectionSettings();
            NavigationService.Navigate(connectionSettings);
        }
    }
}
