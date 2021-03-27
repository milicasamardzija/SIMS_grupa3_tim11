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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PrikaziPacijente.xaml
    /// </summary>
    public partial class PrikaziPacijente : Window
    {
        public PrikaziPacijente()
        {
            InitializeComponent();
        }
        private void izmeniNalogPacijenta(object sender, RoutedEventArgs e)
        {

            IzmeniNalogPacijenta izmenaNaloga = new IzmeniNalogPacijenta();
            izmenaNaloga.ShowDialog();
        }

        private void izbrisiNalogPacijenta(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
