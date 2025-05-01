using BusinessLogicLayer.BLL;
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
using DataTransferObject.Model;

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
            try
            {
                string navn = SpringerNavn.Text;
                DateTime? foedselsdato = FodselsdatoPicker.SelectedDate;
                string kontaktNavn = KontaktNavn.Text;
                string kontaktTelefon = KontaktTelefon.Text;
                string kontaktEmail = KontaktEmail.Text;
                List<string> valgteHold = new List<string>();

                if (Hold1.IsChecked == true) valgteHold.Add(Hold1.Content.ToString());
                if (Hold2.IsChecked == true) valgteHold.Add(Hold2.Content.ToString());
                if (Hold3.IsChecked == true) valgteHold.Add(Hold3.Content.ToString());
                if (Hold4.IsChecked == true) valgteHold.Add(Hold4.Content.ToString());
                SpringerBLL.CreateSpringer(navn, foedselsdato, kontaktNavn, kontaktTelefon, kontaktEmail, valgteHold);


                MessageBox.Show($"Springeren '{navn}' er oprettet med {valgteHold.Count} hold valgt og fødselsdato {foedselsdato:dd-MM-yyyy}.",
                    "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch
            {
                MessageBox.Show("Alle felter blev ikke udfyldt korrekt", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}
