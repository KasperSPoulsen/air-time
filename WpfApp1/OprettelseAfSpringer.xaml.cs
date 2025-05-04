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
    /// Interaction logic for OprettelseAfSpringer.xaml
    /// </summary>
    public partial class OprettelseAfSpringer : Window
    {

        private DataTransferObject.Model.Konkurrence Konkurrence = null;



        private List<DataTransferObject.Model.Springer> ValgteSpringereDerSkalMed = new List<DataTransferObject.Model.Springer>();



        public OprettelseAfSpringer(DataTransferObject.Model.Konkurrence k)
        {
            InitializeComponent();
            Konkurrence = k;
            LoadSpringere();

        }

        public void LoadSpringere()
        {
            List<DataTransferObject.Model.Springer> springere = SpringerBLL.GetAllSpringere();
            SpringerListBox.ItemsSource = springere;
        }

        private void ValgteSpringerSkalMed(object sender, SelectionChangedEventArgs e)
        {
            var valgteSpringere = SpringerListBox.SelectedItems.Cast<DataTransferObject.Model.Springer>();
            foreach (var springer in valgteSpringere)
            {
                if (!ValgteSpringereDerSkalMed.Contains(springer))
                {
                    ValgteSpringereDerSkalMed.Add(springer);
                }
            }
        }

        private void TilfoejTilKonk(object sender, RoutedEventArgs e)
        {
            foreach (var springer in ValgteSpringereDerSkalMed)
            {
                if (!Konkurrence.Springere.Contains(springer))
                {
                    Konkurrence.Springere.Add(springer);
                }
            }
            this.Close();
        }
    }
}
