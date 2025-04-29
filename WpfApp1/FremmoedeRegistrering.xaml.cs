using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for FremmoedeRegistrering.xaml
    /// </summary>
    public partial class FremmoedeRegistrering : Window
    {
        private string valgtHoldNavn = null;

        private Dictionary<string, List<string>> holdData = new Dictionary<string, List<string>>()
        {
            { "Tirsdag hold 1", new List<string> { "Emil", "Frederik", "Anna" } },
            { "Tirsdag hold 2", new List<string> { "Maja", "Jonas", "Sofie" } },
            { "Torsdag hold 1", new List<string> { "William", "Oliver", "Ida" } },
            { "Torsdag hold 2", new List<string> { "Laura", "Mikkel", "Josefine" } },
        };

        public FremmoedeRegistrering()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            valgtHoldNavn = (sender as RadioButton)?.Content.ToString();

            if (valgtHoldNavn != null && holdData.ContainsKey(valgtHoldNavn))
            {
                NavneListe.ItemsSource = holdData[valgtHoldNavn];
            }
        }

        private void MarkerTilstede_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            switch (button.Content.ToString())
            {
                case "Tilstede":
                    button.Content = "Fraværende";
                    break;
                case "Fraværende":
                    button.Content = "Syg";
                    break;
                case "Syg":
                    button.Content = "Tilstede";
                    break;
                default:
                    button.Content = "Tilstede"; // Hvis der opstår noget uventet
                    break;
            }
        }



        private void RegistrerFremmoede(object sender, RoutedEventArgs e)
        {
            if (valgtHoldNavn == null)
            {
                MessageBox.Show("Vælg venligst et hold.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DatoVælger.SelectedDate == null)
            {
                MessageBox.Show("Vælg venligst en dato.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dato = DatoVælger.SelectedDate.Value.ToString("dd-MM-yyyy");

            var result = MessageBox.Show($"Fremmøde registreret for {valgtHoldNavn} på {dato}.", "Fremmøde gemt", MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                this.Close(); 
            }
        }
    }
}
