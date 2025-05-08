using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

public partial class SpringerInfo : Window, INotifyPropertyChanged
    {

        public ObservableCollection<Springer> Springer { get; set; }

        private Springer _selectedSpringer;
        public Springer SelectedSpringer
        {
            get => _selectedSpringer;
            set
            {
                _selectedSpringer = value;
                OnPropertyChanged(nameof(SelectedSpringer));
            }
        }
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
            TraeningsmaalTekst.Text = springer.TraeningsMaal ?? "";
            TilmeldteHold.Text = string.Join(", ", springer.Hold?.Select(h => h.HoldNavn) ?? new List<string>());

            if (springer.KontaktPerson != null)
            {
                KontaktNavnLabel.Content = springer.KontaktPerson.Navn ?? "";
                KontaktTelefonLabel.Content = springer.KontaktPerson.TlfNr ?? "";
                KontaktEmailLabel.Content = springer.KontaktPerson.Mail ?? "";
            }

            if (springer.KonkurrenceSerier != null && springer.KonkurrenceSerier.Any())
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < springer.KonkurrenceSerier.Count; i++)
                {
                    var serie = springer.KonkurrenceSerier[i];
                    sb.AppendLine($"Konkurrenceserie {i + 1}:");
                    sb.AppendLine(string.Join(", ", serie));
                    sb.AppendLine();
                }
                KonkurrenceserierListe.Text = sb.ToString().Trim();
            }
            else
            {
                KonkurrenceserierListe.Text = "Ingen konkurrenceserier.";
            }

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private void OpdaterSpringer_Click(object sender, RoutedEventArgs e)
        {
            
                var edit = new EditSpringer(_springer);
                edit.Closed += Edit_Dialog_Closed;
                //mærk mærke til denne EventHandler – bruges senere når edit vinduet er lukket
                edit.ShowDialog();
            
        }

        private void Edit_Dialog_Closed(object sender, EventArgs e)
        {
            VisSpringerInfo(_springer); // sørger for UI opdateres           

        }
    }
}