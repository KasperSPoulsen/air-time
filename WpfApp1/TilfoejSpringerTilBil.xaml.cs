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
        public TilfoejSpringerTilBil(DataTransferObject.Model.Bil b, DataTransferObject.Model.Konkurrence k)
        {
            InitializeComponent();
            Bil = b;
            DataContext = b;
            Konkurrence = k;
            OpdaterSpringerLister();
            LoadSpringere();
        }

        public void LoadSpringere()
        {
            //List<DataTransferObject.Model.Springer> springere = KonkurrenceBLL.GetAlleSpringerTilKonkurrence(Konkurrence.Id);
            //SpringerListBox.ItemsSource = springere;
            


        }

        private void TilfoejSpringerTilBilKnap(object sender, RoutedEventArgs e)
        {
            var valgteSpringere = SpringerListBox.SelectedItems.OfType<DataTransferObject.Model.Springer>().ToList();

            BilBLL.TilfoejSpringerTilBil(Bil.Id, valgteSpringere);

            OpdaterSpringerLister();




        }


        private void OpdaterSpringerLister()
        {
            
            
                SpringereIBilen.ItemsSource = KonkurrenceBLL.GetSpringerePaaBil(Bil.Id, Konkurrence.Id);

                SpringereIBilen.Items.Refresh();
                SpringerListBox.ItemsSource = KonkurrenceBLL.GetSpringerePaaKonkSomIkErIBil(Konkurrence.Id);
                SpringerListBox.Items.Refresh();


        }
    }
}
