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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Hold.xaml
    /// </summary>
    public partial class Hold : Window
    {
        public Hold()
        {
            InitializeComponent();
        }

        private string valgtHoldNavn = null;

        private Dictionary<string, List<string>> holdData = new Dictionary<string, List<string>>()
        {
            { "Tirsdag hold 1", new List<string> { "Emil", "Frederik", "Anna" } },
            { "Tirsdag hold 2", new List<string> { "Maja", "Jonas", "Sofie" } },
            { "Torsdag hold 1", new List<string> { "William", "Oliver", "Ida" } },
            { "Torsdag hold 2", new List<string> { "Laura", "Mikkel", "Josefine" } },
        };

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            valgtHoldNavn = (sender as RadioButton)?.Content.ToString();

            if (valgtHoldNavn != null && holdData.ContainsKey(valgtHoldNavn))
            {
                NavneListe.ItemsSource = holdData[valgtHoldNavn];
            }
        }

        private void VisTilfoejSpringerVindue(object sender, RoutedEventArgs e)
        {
            var vindue = new TilfoejSpringer();
            vindue.Show();
        }

        private void VisSpringerInfoVindue(object sender, RoutedEventArgs e)
        {
            

            if (NavneListe.SelectedItem == null)
            {
                MessageBox.Show("Vælg venligst en springer fra listen.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var vindue = new SpringerInfo();
            vindue.Show();
        }

    }
}
