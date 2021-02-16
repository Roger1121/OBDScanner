using System.Windows.Navigation;
using LogicLayer;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Quit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Serial.GetInstance().CloseSerial();
            }
            catch (NoDeviceException){}
        }
    }
}
