using Multi_Tools;
using System.Diagnostics;
using System.Windows;

namespace Multi_tools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_PopupWebcam_Click(object sender, RoutedEventArgs e)
        {
            App.ModifyRegistryCam();
        }

        private void Button_InstallPowerToys_Click(object sender, RoutedEventArgs e)
        {
            App.PowerToys();
        }

        private void Button_InstallUnowhyTools_Click(object sender, RoutedEventArgs e)
        {
            App.UnowhyTools();
        }
    }
 }
