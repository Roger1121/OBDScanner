using System.Windows;
using System.Windows.Controls;
using LogicLayer;

namespace Interface
{
    /// <summary>
    /// Logika interakcji dla klasy DTCs.xaml
    /// </summary>
    public partial class DTCs : Page
    {
        public DTCs()
        {
            InitializeComponent();
            text.Text = ReadDTCs();
        }

        private string ReadDTCs() => Serial.GetInstance().ReadTroubleCodes();

        private void ClearDTCs(object sender, RoutedEventArgs e)
        {
            Serial.GetInstance().ClearTroubleCodes();
        }
    }
}
