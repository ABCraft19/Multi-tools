using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace MultiTools.Installation
{
    public interface IInstaller
    {
        void Install();
    }

    public class Installer : IInstaller
    {
        public void Install()
        {
            // Implementation of the Install method
        }
    }

    public partial class InstallationWindow : Window
    {
        public InstallationWindow()
        {
            InitializeComponent();
        }

        public void Button_PopupWebcam_Click(object sender, RoutedEventArgs e)
        {
            ModifyRegistryCam();
        }

        public void Button_PowerToys_Click(object sender, RoutedEventArgs e)
        {
            InstallPowerToys();
        }

        public void Button_UnowhyTools_Click(object sender, RoutedEventArgs e)
        {
            InstallUnowhyTools();
        }

        public static void ModifyRegistryCam()
        {
            try
            {
                string registryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\OEM\Device\Capture";
                string valueName = "NoPhysicalCameraLED";
                int valueData = 1;
                Registry.SetValue(registryPath, valueName, valueData, RegistryValueKind.DWord);
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - Registry modified successfully";
                Trace.WriteLine(logMessage);
                MessageBox.Show("The task was successfully executed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - Authorization error: {ex.Message}";
                Trace.WriteLine(logMessage);
                MessageBox.Show($"Authorization error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - An error occurred: {ex.Message}";
                Trace.WriteLine(logMessage);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void InstallPowerToys()
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "winget",
                        Arguments = "install Microsoft.PowerToys",
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - PowerToys installed successfully";
                Trace.WriteLine(logMessage);
                MessageBox.Show("The installation was successfully executed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - Authorization error: {ex.Message}";
                Trace.WriteLine(logMessage);
                MessageBox.Show($"Authorization error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - An error occurred: {ex.Message}";
                Trace.WriteLine(logMessage);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void InstallUnowhyTools()
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "winget",
                        Arguments = "install 'Unowhy Tools'",
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - Unowhy Tools installed successfully";
                Trace.WriteLine(logMessage);
                MessageBox.Show("The installation was successfully executed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - Authorization error: {ex.Message}";
                Trace.WriteLine(logMessage);
                MessageBox.Show($"Authorization error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                string logMessage = $"{timestamp} - An error occurred: {ex.Message}";
                Trace.WriteLine(logMessage);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
