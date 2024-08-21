using MultiTools.Installation;
using System.Windows;
using Wpf.Ui.Controls;

namespace MultiTools
{
    public partial class MainWindow : Window
    {
        public InstallationWindow _installationWindow { get; }

        public MainWindow(NavigationView navigation)
        {
            DataContext = this;

            InitializeComponent();

            // Get the service
            _installationWindow = App.GetService<InstallationWindow>();

            // Use the service
            if (_installationWindow != null)
            {
                // Show the window
                _installationWindow.Show();
            }
        }

        // Call static methods using the class name
        public void Button_PopupWebcam_Click(object sender, RoutedEventArgs e)
        {
            InstallationWindow.ModifyRegistryCam();
        }

        public void Button_PowerToys_Click(object sender, RoutedEventArgs e)
        {
            InstallationWindow.InstallPowerToys();
        }

        public void Button_UnowhyTools_Click(object sender, RoutedEventArgs e)
        {
            InstallationWindow.InstallUnowhyTools();
        }
    }
}
