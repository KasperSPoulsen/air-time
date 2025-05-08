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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for TilfoejSpringerTilBil.xaml
    /// </summary>
    public partial class TilfoejSpringerTilBil : Window
    {

        private DataTransferObject.Model.Bil Bil = null;
        private DataTransferObject.Model.Konkurrence Konkurrence = null;
        private List<DataTransferObject.Model.Springer> _springereIBilen = new List<DataTransferObject.Model.Springer>();
        private List<DataTransferObject.Model.Springer> _springerePaaKonkSomIkErIBil = new List<DataTransferObject.Model.Springer>();
        public TilfoejSpringerTilBil(DataTransferObject.Model.Bil b, DataTransferObject.Model.Konkurrence k)
        {
            InitializeComponent();
            Bil = b;
            DataContext = b;
            Konkurrence = k;
            OpdaterSpringerLister();
            
        }

        

        private void TilfoejSpringerTilBilKnap(object sender, RoutedEventArgs e)
        {
            var valgteSpringere = SpringerListBox.SelectedItems.OfType<DataTransferObject.Model.Springer>().ToList();

            foreach (var springer in valgteSpringere)
            {
                if (!_springereIBilen.Contains(springer))
                {
                    _springereIBilen.Add(springer);
                }
            }

            foreach (var springer in valgteSpringere)
            {
                if (_springerePaaKonkSomIkErIBil.Contains(springer))
                {
                    _springerePaaKonkSomIkErIBil.Remove(springer);
                }
            }

            SpringereIBilen.ItemsSource = _springereIBilen;
            SpringerListBox.ItemsSource = _springerePaaKonkSomIkErIBil;

            SpringereIBilen.Items.Refresh();
            SpringerListBox.Items.Refresh();




        }

        private void FjernSpringerFraBilKnap(object sender, RoutedEventArgs e)
        {
            var valgteSpringere = SpringereIBilen.SelectedItems.OfType<DataTransferObject.Model.Springer>().ToList();

            foreach (var springer in valgteSpringere)
            {
                if (!_springerePaaKonkSomIkErIBil.Contains(springer))
                {
                    _springerePaaKonkSomIkErIBil.Add(springer);
                }
            }

            foreach (var springer in valgteSpringere)
            {
                if (_springereIBilen.Contains(springer))
                {
                    _springereIBilen.Remove(springer);
                }
            }

            SpringereIBilen.ItemsSource = _springereIBilen;
            SpringerListBox.ItemsSource = _springerePaaKonkSomIkErIBil;

            SpringereIBilen.Items.Refresh();
            SpringerListBox.Items.Refresh();



        }


        private void OpdaterSpringerLister()
        {
            _springereIBilen = KonkurrenceBLL.GetSpringerePaaBil(Bil.Id, Konkurrence.Id);
            _springerePaaKonkSomIkErIBil = KonkurrenceBLL.GetSpringerePaaKonkSomIkErIBil(Konkurrence.Id);



            SpringereIBilen.ItemsSource = _springereIBilen;

                SpringereIBilen.Items.Refresh();
            SpringerListBox.ItemsSource = _springerePaaKonkSomIkErIBil;
                SpringerListBox.Items.Refresh();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BilBLL.OpdaterSpringerIBil(_springereIBilen, _springerePaaKonkSomIkErIBil, Bil.Id, Konkurrence.Id);
            this.Close();
        }
    }
}
