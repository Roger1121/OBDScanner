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
        public ActionMenu(Serial serial)
        {
            InitializeComponent();
            OBD = serial;
            MessageBox.Show(OBD.ToString());
        }
        public Serial OBD { get; set; }

        private void ShowCurrentData(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowFreezeFrameData(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDTCs(object sender, RoutedEventArgs e)
        {

        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Serial.GetInstance().CloseSerial();
            Application.Current.Shutdown();
        }
    }
}
