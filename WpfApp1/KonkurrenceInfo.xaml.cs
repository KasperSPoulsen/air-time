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

        private BusinessLogicLayer.BLL.SpringerBLL springerBLL = new BusinessLogicLayer.BLL.SpringerBLL();



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
            List<DataTransferObject.Model.Springer> springere = springerBLL.GetAllSpringere();
            SpringerListBox.ItemsSource = springere;
        }

        public void LoadBiler()
        {
            List<DataTransferObject.Model.Bil> biler = KonkurrenceBLL.GetAlleBilerTilKonkurrence(Konkurrence.Id);
            foreach (var bil in biler)
            {
                Console.WriteLine($"Bil ID: {bil.Id}");
                Console.WriteLine(bil.KontaktPerson != null
                    ? $"KontaktPerson Navn: {bil.KontaktPerson.Navn}, KontaktPerson ID: {bil.KontaktPerson.Id}"
                    : "KontaktPerson er null");
            }

            BilListBox.ItemsSource = biler;

        }
        




        private void TiloejBillistTilKonk(object sender, RoutedEventArgs e)
        {
            var vindue = new OprettelseAfBil(Konkurrence);
            vindue.ShowDialog();
            LoadBiler();
        }

        private void ValgteBilSkalSlettes(object sender, SelectionChangedEventArgs e)
        {
            var valgteBil = BilListBox.SelectedItem as DataTransferObject.Model.Bil;

            if (valgteBil != null)
            {
                skalSlettes = valgteBil;
                Console.WriteLine($"Valgt Bil Id: {skalSlettes.Id}");
            }
            else
            {
                Console.WriteLine("Ingen bil valgt.");
            }
        }


        private void RedigereBillist(object sender, RoutedEventArgs e)
        {
            BilBLL bilBLL = new BilBLL();
            //Konkurrence.Biler.Remove(skalSlettes.Id);
            bilBLL.SletBil(skalSlettes.Id);
            LoadBiler();
        }
    }
}
