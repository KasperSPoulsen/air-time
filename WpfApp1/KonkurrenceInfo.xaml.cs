using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KonkurrenceInfo.xaml
    /// </summary>
    public partial class KonkurrenceInfo : Window
    {
        private DataTransferObject.Model.Konkurrence Konkurrence = null;


        private DataTransferObject.Model.Bil skalSlettes = null;




        public KonkurrenceInfo(DataTransferObject.Model.Konkurrence k)
        {
            InitializeComponent();
            Konkurrence = k;
            this.DataContext = k;

            LoadSpringere();
            LoadBiler();
        }

        public void LoadSpringere()
        {
            List<DataTransferObject.Model.Springer> springere = KonkurrenceBLL.GetAlleSpringerTilKonkurrence(Konkurrence.Id);
            SpringerListBox.ItemsSource = springere;
        }

        public void LoadBiler()
        {
            List<DataTransferObject.Model.Bil> biler = KonkurrenceBLL.GetAlleBilerTilKonkurrence(Konkurrence.Id);
            BilListBox.ItemsSource = biler;

        }



        private void TiloejBillistTilKonk(object sender, RoutedEventArgs e)
        {
            var vindue = new OprettelseAfBil(Konkurrence);
            vindue.ShowDialog();
            LoadBiler();
        }

        private void ValgteBil(object sender, SelectionChangedEventArgs e)
        {
            var valgteBil = BilListBox.SelectedItem as DataTransferObject.Model.Bil;

            if (valgteBil != null)
            {
                skalSlettes = valgteBil;
            }
        }


        private void RedigereBillist(object sender, RoutedEventArgs e)
        {
            BilBLL bilBLL = new BilBLL();
            //Konkurrence.Biler.Remove(skalSlettes.Id);
            bilBLL.SletBil(skalSlettes.Id);
            LoadBiler();
        }

        private void TilfoejSpringerTilKonk(object sender, RoutedEventArgs e)
        {
            var vindue = new OprettelseAfSpringer(Konkurrence);
            vindue.ShowDialog();
            LoadSpringere();
        }

        private void IndPaaValgteBillist(object sender, RoutedEventArgs e)
        {
            var vindue = new TilfoejSpringerTilBil(skalSlettes, Konkurrence);
            vindue.ShowDialog();

        }
    }
}
