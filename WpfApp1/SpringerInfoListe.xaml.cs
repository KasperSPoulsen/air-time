using BusinessLogicLayer.BLL;
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
    /// Interaction logic for SpringerInfoListe.xaml
    /// </summary>
    public partial class SpringerInfoListe : Window
    {
        public SpringerInfoListe()
        {
            InitializeComponent();
            DataContext = SpringerBLL.GetAllSpringere();

        }

        private void SpringerListe_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SpringerListe.SelectedItem is DataTransferObject.Model.Springer selectedSpringer)
            {
                var infoWindow = new SpringerInfo(selectedSpringer);
                infoWindow.ShowDialog();
            }
        }
    }
}
