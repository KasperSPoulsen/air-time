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
    /// Interaction logic for TidligereTraeninger.xaml
    /// </summary>
    public partial class TidligereTraeninger : Window
    {
        public TidligereTraeninger()
        {
            InitializeComponent();


            TraeningBLL BLL = new TraeningBLL();

            var senesteTraening = BLL.GetSenesteTraening();
            var tilmeldte = BLL.GetTilmeldte();

            DatoLabel1.Content = tilmeldte;
            TraeningNavn1.Content = senesteTraening;


        }


    }
}
