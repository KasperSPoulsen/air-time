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
using DataTransferObject.Model;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditSpringer.xaml
    /// </summary>
    public partial class EditSpringer : Window
    {
        private Springer springer;

        public EditSpringer(Springer p)
        {
            InitializeComponent();
            springer = p;
            springerDialogGrid.DataContext = springer;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
