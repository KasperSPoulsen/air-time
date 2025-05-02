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
    /// Interaction logic for Konkurrence.xaml
    /// </summary>
    public partial class Konkurrence : Window
    {

        private KonkurrenceBLL konkurrenceBLL = new KonkurrenceBLL();
        public Konkurrence()
        {
            InitializeComponent();
            LoadKonkurrencer();
        }

        private void OpretKonkurrence(object sender, RoutedEventArgs e)
        {
            var vindue = new OprettelseAfKonkurrence();
            vindue.ShowDialog();
            LoadKonkurrencer();
        }

        private void LoadKonkurrencer()
        {
            List<DataTransferObject.Model.Konkurrence> konkurrencer = konkurrenceBLL.GetAllKonkurrencer();
            KonkurrenceListBox.ItemsSource = konkurrencer;
        }

        private void ValgteKonkurrence(object sender, SelectionChangedEventArgs e)
        {
            var valgteKonkurrence = KonkurrenceListBox.SelectedItem as DataTransferObject.Model.Konkurrence;
            if ( valgteKonkurrence != null)
            {
                var vindue = new KonkurrenceInfo(valgteKonkurrence);
                vindue.Show();
            }
            else
            {
                MessageBox.Show("Vælg venligst en konkurrence.");
                return;
            }
        }
    }
}
