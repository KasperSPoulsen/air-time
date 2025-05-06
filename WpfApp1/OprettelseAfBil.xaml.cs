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
    /// Interaction logic for OprettelseAfBil.xaml
    /// </summary>
    public partial class OprettelseAfBil : Window
    {
        private DataTransferObject.Model.Konkurrence Konkurrence = null;

        //private BusinessLogicLayer.BLL.KonkurrenceBLL konkurrenceBLL;

        private DataTransferObject.Model.KontaktPerson KontaktPerson = null;

        private BusinessLogicLayer.BLL.KontaktPersonBLL kontaktPersonBLL = new BusinessLogicLayer.BLL.KontaktPersonBLL();



        public OprettelseAfBil(DataTransferObject.Model.Konkurrence k)
        {
            InitializeComponent();
            Konkurrence = k;
            //konkurrenceBLL = new BusinessLogicLayer.BLL.KonkurrenceBLL();
            LoadKontaktPersoner();
        }
        public void LoadKontaktPersoner()
        {
            List<DataTransferObject.Model.KontaktPerson> kontaktPersoner = kontaktPersonBLL.GetAllKontaktPersoner();
            KontaktPersonListBox.ItemsSource = kontaktPersoner;
        }
        private void ValgteKontaktPerson(object sender, SelectionChangedEventArgs e)
        {
            var valgteKontaktPerson = KontaktPersonListBox.SelectedItem as DataTransferObject.Model.KontaktPerson;
            if (valgteKontaktPerson != null)
            {
                KontaktPerson = valgteKontaktPerson;

            }
        }

        private void OpretBillistFinal(object sender, RoutedEventArgs e)
        {
            BilBLL bilBLL = new BilBLL();
            bilBLL.CreateBil(KontaktPerson, Konkurrence);
            
            
            this.Close();
        }
    }
}
