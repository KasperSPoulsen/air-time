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
    /// Interaction logic for SpringerInfo.xaml
    /// </summary>
    public partial class SpringerInfo : Window
    {
        public SpringerInfo()
        {
            InitializeComponent();
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
}
