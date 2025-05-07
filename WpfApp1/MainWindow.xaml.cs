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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTransferObject.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Springer springer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VisFremmoedeRegistreringsVindue(object sender, RoutedEventArgs e)
        {
            var vindue = new FremmoedeRegistrering(); 
            vindue.Show();
        }

        private void VisHoldVindue(object sender, RoutedEventArgs e)
        {

            var vindue = new Hold();
            vindue.Show();
        }

        private void VisKonkurrenceVindue(object sender, RoutedEventArgs e)
        {
            var vindue = new Konkurrence();
            vindue.Show();
        }


        private void Tidligere_Træninger_Click(object sender, RoutedEventArgs e)
        {
            var vindue = new TidligereTraeninger();
        }
        private void InformationOmSpringer_Click(object sender, RoutedEventArgs e)
        {
            var vindue = new SpringerInfoListe();
            vindue.Show();
        }
    }
}
