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
using BusinessLogicLayer.BLL;
using DataTransferObject.Model;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditSpringer.xaml
    /// </summary>
    public partial class EditSpringer : Window
    {
        private Springer _springer;
        private int konkurrenceSerieCount = 1;


        public EditSpringer(Springer p)
        {
            InitializeComponent();
            _springer = p;
            springerDialogGrid.DataContext = _springer;

            NavnTextBox.Text = _springer.Navn ?? "";
            FødselsdagTextBox.Text = _springer.Foedselsdato?.ToString("dd-MM-yyyy") ?? "";
            TræningsmålTextBox.Text = _springer.TraeningsMaal ?? "";
            TilmeldteHoldTextBox.Text = string.Join(", ", _springer.Hold?.Select(h => h.HoldNavn) ?? new List<string>());

            if (_springer.KontaktPerson != null)
            {
                KontaktNavnTextBox.Text = _springer.KontaktPerson.Navn ?? "";
                KontaktTelefonTextBox.Text = _springer.KontaktPerson.TlfNr ?? "";
                KontaktEmailTextBox.Text = _springer.KontaktPerson.Mail ?? "";
            }

            if (_springer.KonkurrenceSerieList != null && _springer.KonkurrenceSerieList.Any())
            {
                KonkurreneSerie1Box.Text = _springer.KonkurrenceSerieList[0];
                konkurrenceSerieCount = 1;

                for (int i = 1; i < _springer.KonkurrenceSerieList.Count; i++)
                {
                    konkurrenceSerieCount++;
                    var newLabel = new TextBlock
                    {
                        Text = $"Konkurrenceserie {konkurrenceSerieCount}:",
                        Margin = new Thickness(0, 0, 0, 5)
                    };

                    var newBox = new TextBox
                    {
                        Name = $"KonkurrenceSerieBox{konkurrenceSerieCount}",
                        Margin = new Thickness(0, 0, 0, 10),
                        Text = _springer.KonkurrenceSerieList[i]
                    };

                    KonkurrenceSerierPanel.Children.Add(newLabel);
                    KonkurrenceSerierPanel.Children.Add(newBox);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddKonkurrenceSerie_Click(object sender, RoutedEventArgs e)
        {
            konkurrenceSerieCount++;

            var newLabel = new TextBlock
            {
                Text = $"Konkurrenceserie {konkurrenceSerieCount}:",
                Margin = new Thickness(0, 0, 0, 5)
            };

            var newBox = new TextBox
            {
                Name = $"KonkurrenceSerieBox{konkurrenceSerieCount}",
                Margin = new Thickness(0, 0, 0, 10)
            };

            KonkurrenceSerierPanel.Children.Add(newLabel);
            KonkurrenceSerierPanel.Children.Add(newBox);
        }

        private void GemOplysninger_Click(object sender, RoutedEventArgs e)
        {
            List<string> konkurrenceSerier = new List<string>();

            foreach (var child in KonkurrenceSerierPanel.Children)
            {
                if (child is TextBox box && !string.IsNullOrWhiteSpace(box.Text))
                {
                    konkurrenceSerier.Add(box.Text.Trim());
                }
            }

            _springer.KonkurrenceSerieList = konkurrenceSerier;

            _springer.Navn = NavnTextBox.Text.Trim();
            _springer.TraeningsMaal = TræningsmålTextBox.Text.Trim();

            if (_springer.KontaktPerson != null)
            {
                _springer.KontaktPerson.Navn = KontaktNavnTextBox.Text.Trim();
                _springer.KontaktPerson.TlfNr = KontaktTelefonTextBox.Text.Trim();
                _springer.KontaktPerson.Mail = KontaktEmailTextBox.Text.Trim();
            }

            try
            {
                SpringerBLL.UpdateSpringer(_springer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl ved opdatering: {ex.Message}", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
