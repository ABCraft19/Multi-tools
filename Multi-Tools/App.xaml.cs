using System;
using System.Windows;
using Microsoft.Win32;
using Multi_tools;

namespace Multi_Tools
{
    public partial class App : Application
    {
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

        // ...

        // Ajoutez cette méthode pour modifier le Registre et journaliser les actions
        public static void ModifyRegistry()
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
    }
}
