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
    /// Interaction logic for Hold.xaml
    /// </summary>
    public partial class Hold : Window
    {
        private string valgtHoldNavn;
        public Hold()
        {
            InitializeComponent();
        }

        

        

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            valgtHoldNavn = (sender as RadioButton)?.Content.ToString();

            OpdaterSpringerListe(sender, e);


        }

        private void OpdaterSpringerListe(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(valgtHoldNavn))
            {
                NavneListe.ItemsSource = HoldBLL.GetSpringerePaaHold(valgtHoldNavn);
            }
        }

        private void VisTilfoejSpringerVindue(object sender, RoutedEventArgs e)
        {
            var vindue = new TilfoejSpringer();
            vindue.Closed += OpdaterSpringerListe;
            vindue.Show();
        }

        private void VisSpringerInfoVindue(object sender, RoutedEventArgs e)
        {
            if (NavneListe.SelectedItem == null)
            {
                MessageBox.Show("Vælg venligst en springer fra listen.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var valgtSpringer = (Springer)NavneListe.SelectedItem;
            var vindue = new SpringerInfo(valgtSpringer);

            vindue.Show();
        }


    }
}
