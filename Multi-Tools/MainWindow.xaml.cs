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
            App.ModifyRegistrycam();
        }

        private void Button_InstallPowerToys_Click(object sender, RoutedEventArgs e)
        {
            // Créez un processus pour exécuter la commande winget
            Process process = new Process();
            process.StartInfo.FileName = "winget"; // Spécifiez le nom de l'exécutable
            process.StartInfo.Arguments = "install Microsoft.PowerToys"; // Spécifiez les arguments de la commande winget pour installer PowerToys
            process.StartInfo.UseShellExecute = false; // N'utilisez pas le shell de démarrage
            process.StartInfo.RedirectStandardOutput = true; // Redirigez la sortie standard pour récupérer la sortie de la commande
            process.Start(); // Lancez le processus

            // Attendez que le processus se termine
            process.WaitForExit();

            // Lisez la sortie standard pour récupérer les résultats de la commande
            string output = process.StandardOutput.ReadToEnd();

            // Affichez la sortie de la commande
            MessageBox.Show(output, "Résultat de l'installation", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    }
}
