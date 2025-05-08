using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessLogicLayer.BLL;
using DataTransferObject.Model;

namespace WpfApp1
{
    public partial class EditSpringer : Window
    {
        private Springer _springer;
        private int konkurrenceSerieCount = 0;
        private List<TextBox> konkurrenceSerieTextBoxes = new List<TextBox>();

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

            if (_springer.KonkurrenceSerier != null)
            {
                foreach (var serie in _springer.KonkurrenceSerier)
                {
                    AddKonkurrenceSerie(serie);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddKonkurrenceSerie(string initialText = "")
        {
            konkurrenceSerieCount++;

            var label = new TextBlock
            {
                Text = $"Konkurrenceserie {konkurrenceSerieCount}:",
                Margin = new Thickness(0, 10, 0, 5)
            };

            var textBox = new TextBox
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = initialText
            };

            konkurrenceSerieTextBoxes.Add(textBox);

            KonkurrenceSerierPanel.Children.Add(label);
            KonkurrenceSerierPanel.Children.Add(textBox);
        }

        private void AddKonkurrenceSerie_Click(object sender, RoutedEventArgs e)
        {
            AddKonkurrenceSerie();
        }

        private void GemOplysninger_Click(object sender, RoutedEventArgs e)
        {
            _springer.KonkurrenceSerier = konkurrenceSerieTextBoxes
                .Select(tb => tb.Text.Trim())
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .ToList();

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
