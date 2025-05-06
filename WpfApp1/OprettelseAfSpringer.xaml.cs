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


        private void TilfoejTilKonk(object sender, RoutedEventArgs e)
        {
            var valgteSpringere = SpringerListBox.SelectedItems
                .OfType<DataTransferObject.Model.Springer>()
                .ToList();

            


            foreach (var springer in valgteSpringere)
            {
                if (!Konkurrence.Springere.Contains(springer))
                {
                    KonkurrenceBLL.TilfoejSpringereTilKonkurrence(Konkurrence.Id, valgteSpringere);
                    //Konkurrence.Springere.Add(springer);
                }
            }
            this.Close();
        }
    }
}
