using MultiTools.Pages;
using System.Windows;
using Wpf.Ui.Controls;

namespace MultiTools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(NavigationPageModel model);

            DataContext = model;
            Loaded += (_, _) => Dash.Navigate(type(MyDashboardClass));
            // Ensure navigationView (Dash) is properly initialized before attaching the event handler
            this.Loaded += (s, e) =>
            {
                if (Dash != null)
                {
                    Dash.SelectionChanged += OnNavigationViewSelectionChanged;
                }
                else
                {
                    // Handle the null case appropriately, e.g., log an error or throw an exception
                    System.Windows.MessageBox.Show("NavigationView 'Dash' is not initialized.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            };
        }

        private void OnNavigationViewSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Dash.SelectedItem is NavigationViewItem selectedItem)
            {
                switch (selectedItem.Tag)
                {
                    case "HomePage":
                        MainFrame.Navigate(new System.Uri("Pages/Dash.xaml", System.UriKind.Relative));
                        break;
                    case "InstallationPage":
                        MainFrame.Navigate(new System.Uri("Pages/Installation.xaml", System.UriKind.Relative));
                        break;
                }
            }
        }

        // Remove this property as it is not needed
        // public NavigationView navigationView { get; set; }
    }
}
