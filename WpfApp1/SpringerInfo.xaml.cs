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
    /// Interaction logic for SpringerInfo.xaml
    /// </summary>

public partial class SpringerInfo : Window
    {
        private Springer _springer;

        public SpringerInfo(Springer springer)
        {
            InitializeComponent();
            _springer = springer;
            VisSpringerInfo(springer);
        }


        private void VisSpringerInfo(Springer springer)
        {
            NavnLabel.Content = springer.Navn ?? "";
            FødselsdagLabel.Content = springer.Foedselsdato?.ToString("dd-MM-yyyy") ?? "";
            HoldLabel.Content = string.Join(", ", springer.Hold?.Select(h => h.HoldNavn) ?? new List<string>());
            TræningsmålTekst.Text = springer.TraeningsMaal ?? "";

            if (springer.KontaktPerson != null)
            {
                KontaktNavnLabel.Content = springer.KontaktPerson.Navn ?? "";
                KontaktTelefonLabel.Content = springer.KontaktPerson.TlfNr ?? "";
                KontaktEmailLabel.Content = springer.KontaktPerson.Mail ?? "";
            }

            // Hvis du har springserier, sæt dem her:
            SpringserierListe.ItemsSource = springer.KonkurrenceSerie;
        }
    }


    /*
     * NavnLabel.Content = springer.Navn ?? "";
        TelefonLabel.Content = springer.Telefonnummer ?? "";
FødselsdagLabel.Content = springer.Fødselsdag?.ToString("dd-MM-yyyy") ?? "";
HoldLabel.Content = string.Join(", ", springer.Hold ?? new List<string>());
KontaktNavnLabel.Content = springer.KontaktNavn ?? "";
KontaktTelefonLabel.Content = springer.KontaktTelefon ?? "";
KontaktEmailLabel.Content = springer.KontaktEmail ?? "";

SpringserierListe.ItemsSource = springer.Springserier; // List<SpringSerie>
TræningsmålTekst.Text = springer.Træningsmål ?? "";
     */
}

