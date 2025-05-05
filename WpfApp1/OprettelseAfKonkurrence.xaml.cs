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
    /// Interaction logic for OprettelseAfKonkurrence.xaml
    /// </summary>
    public partial class OprettelseAfKonkurrence : Window
    {
        public OprettelseAfKonkurrence()
        {
            InitializeComponent();
        }

        private void OpretSlut(object sender, RoutedEventArgs e)
        {
            string adresse =AdresseTextBox.Text;
            string navn = NavnTextBox.Text;
            DateTime? dato = DatoPicker.SelectedDate;
            if (string.IsNullOrEmpty(adresse) || string.IsNullOrEmpty(navn) || dato == null)
            {
                MessageBox.Show("Udfyld venligst alle felter.");
                return;
            }
            if (dato < DateTime.Now)
            {
                MessageBox.Show("Datoen skal være i fremtiden.");
                return;
            }
            KonkurrenceBLL k = new KonkurrenceBLL();
            k.CreateKonkurrence(adresse, navn, dato);
            this.Close();
        }
    }
}
