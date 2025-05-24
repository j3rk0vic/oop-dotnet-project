using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string championship = rbMen.IsChecked == true ? "men" : "women";
            string language = rbCroatian.IsChecked == true ? "hr" : "en";
            string? resolution = (cbResolution.SelectedItem as ComboBoxItem)?.Content.ToString();

            string settings = $"{championship}, {language}, {resolution}";
            File.WriteAllText("settings.txt", settings);

            MessageBox.Show("Settings saved!");

            TeamSelectionWindow teamWindow = new TeamSelectionWindow();
            teamWindow.Show();
            this.Close();
        }
    }
}