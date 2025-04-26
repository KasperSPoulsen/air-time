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
    /// Interaction logic for TilfoejSpringer.xaml
    /// </summary>
    public partial class TilfoejSpringer : Window
    {
        public TilfoejSpringer()
        {
            InitializeComponent();
        }

        private void GemSpringerClick(object sender, RoutedEventArgs e)
        {
            string navn = SpringerNavn.Text;
            string kontaktNavn = KontaktNavn.Text;
            string kontaktTelefon = KontaktTelefon.Text;

            List<string> valgteHold = new List<string>();

            if (Hold1.IsChecked == true) valgteHold.Add(Hold1.Content.ToString());
            if (Hold2.IsChecked == true) valgteHold.Add(Hold2.Content.ToString());
            if (Hold3.IsChecked == true) valgteHold.Add(Hold3.Content.ToString());
            if (Hold4.IsChecked == true) valgteHold.Add(Hold4.Content.ToString());

            if (string.IsNullOrWhiteSpace(navn) || string.IsNullOrWhiteSpace(kontaktNavn) || string.IsNullOrWhiteSpace(kontaktTelefon))
            {
                MessageBox.Show("Udfyld venligst alle felter!", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (valgteHold.Count == 0)
            {
                MessageBox.Show("Vælg mindst ét hold.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Her kunne skal vi få gemt springeren ned i databasen
            MessageBox.Show($"Springeren '{navn}' er oprettet med {valgteHold.Count} hold valgt.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close(); 
        }

    }
}
