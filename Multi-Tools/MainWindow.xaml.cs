using Multi_Tools;
using System.Windows;

namespace Multi_tools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Appel à la méthode ModifyRegistry définie dans la classe App
            App.ModifyRegistry();
        }
    }
}
