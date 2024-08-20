using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiTools.Installation;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui;
using System.Windows.Controls;

namespace MultiTools
{
    public partial class MainWindow : Window
    {
        private readonly InstallationWindow _installationWindow;

        public MainWindow()
        {
            InitializeComponent();

            // Get the service
            _installationWindow = App.GetService<InstallationWindow>();

            // Use the service
            if (_installationWindow != null)
            {
                // Show the window
                _installationWindow.Show();

                // Call static methods using the class name
                InstallationWindow.ModifyRegistryCam();
                InstallationWindow.InstallPowerToys();
                InstallationWindow.InstallUnowhyTools();
            }
        }
    }
}
