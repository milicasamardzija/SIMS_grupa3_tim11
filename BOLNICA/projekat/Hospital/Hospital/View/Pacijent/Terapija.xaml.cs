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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Terapija.xaml
    /// </summary>
    public partial class Terapija : Window
    {
        private PrintDialog _printDialog = new PrintDialog();
        public Terapija()
        {
            InitializeComponent();
            Calendar.Days[0].Notes = "ampril";
        }

        private void pdf(object sender, RoutedEventArgs e)
        {
              _printDialog.PrintVisual(new Izvjestaj(), "Izveštaj 1");
          
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {

        }
    }
}
