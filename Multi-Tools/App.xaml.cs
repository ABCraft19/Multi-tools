using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;
using Microsoft.Win32;

namespace Multi_Tools
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            // Vérifiez si l'application est lancée en tant qu'administrateur
            if (!IsRunningAsAdministrator())
            {
                // Si elle ne l'est pas, relancez l'application en tant qu'administrateur
                RestartAsAdministrator();
                return;
            }

            var app = new App();
            app.Run();
        }

        // Vérifie si l'application est lancée en tant qu'administrateur
        private static bool IsRunningAsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // Relance l'application en tant qu'administrateur
        private static void RestartAsAdministrator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
            startInfo.Verb = "runas"; // Exécuter avec des privilèges d'administrateur

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du redémarrage de l'application en tant qu'administrateur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Ajoutez cet événement au démarrage de l'application
            Startup += App_Startup;

            // Configurer le système de journalisation ici si nécessaire
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener("log.txt"));
            System.Diagnostics.Trace.AutoFlush = true;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // Affichez votre fenêtre principale ici, si nécessaire
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        // Ajoutez cette méthode pour modifier le Registre et journaliser les actions
        public static void ModifyRegistryCam()
        {
            try
            {
                // Spécifiez le chemin d'accès au Registre
                string registryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\OEM\Device\Capture";

                // Nom de la clé DWORD à ajouter/modifier
                string valueName = "NoPhysicalCameraLED";

                // Valeur DWORD à définir
                int valueData = 1;

                // Ajouter la clé DWORD au Registre
                Registry.SetValue(registryPath, valueName, valueData, RegistryValueKind.DWord);

                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Registre modifié avec succès";

                // Journalisation du succès
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez une confirmation à l'utilisateur
                MessageBox.Show("La tâche a été exécutée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Erreur d'autorisation : {ex.Message}";

                // Journalisation de l'erreur d'autorisation
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez un message d'erreur à l'utilisateur avec le code d'erreur
                MessageBox.Show($"Erreur d'autorisation : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Une erreur s'est produite : {ex.Message}";

                // Journalisation de l'erreur générale
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez un message d'erreur générique à l'utilisateur avec le code d'erreur
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void PowerToys()
        {
            try
            {
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

                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - PowerToys installer avec succès";

                // Journalisation du succès
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez une confirmation à l'utilisateur
                MessageBox.Show("L'installation a été exécutée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Erreur d'autorisation : {ex.Message}";

                // Journalisation de l'erreur d'autorisation
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez un message d'erreur à l'utilisateur avec le code d'erreur
                MessageBox.Show($"Erreur d'autorisation : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Une erreur s'est produite : {ex.Message}";

                // Journalisation de l'erreur générale
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez un message d'erreur générique à l'utilisateur avec le code d'erreur
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void UnowhyTools()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "winget"; // Spécifiez le nom de l'exécutable
                process.StartInfo.Arguments = "install 'Unowhy Tools'"; // Spécifiez les arguments de la commande winget pour installer PowerToys
                process.StartInfo.UseShellExecute = false; // N'utilisez pas le shell de démarrage
                process.StartInfo.RedirectStandardOutput = true; // Redirigez la sortie standard pour récupérer la sortie de la commande
                process.Start(); // Lancez le processus

                // Attendez que le processus se termine
                process.WaitForExit();

                // Lisez la sortie standard pour récupérer les résultats de la commande
                string output = process.StandardOutput.ReadToEnd();

                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Unowhy Tools installer avec succès";

                // Journalisation du succès
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez une confirmation à l'utilisateur
                MessageBox.Show("L'installation a été exécutée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Erreur d'autorisation : {ex.Message}";

                // Journalisation de l'erreur d'autorisation
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez un message d'erreur à l'utilisateur avec le code d'erreur
                MessageBox.Show($"Erreur d'autorisation : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Obtenez le timestamp au format demandé
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");

                // Construisez le message de journalisation avec le timestamp
                string logMessage = $"{timestamp} - Une erreur s'est produite : {ex.Message}";

                // Journalisation de l'erreur générale
                System.Diagnostics.Trace.WriteLine(logMessage);

                // Affichez un message d'erreur générique à l'utilisateur avec le code d'erreur
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
