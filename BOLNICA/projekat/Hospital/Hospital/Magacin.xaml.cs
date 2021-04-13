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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Magacin.xaml
    /// </summary>
    public partial class Magacin : UserControl
    {
        public Boolean tool = false;
        public Magacin()
        {
            InitializeComponent();
            MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new DodajInventarDijalog(MagacinFrame));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new IzbrisiInventarDijalog(MagacinFrame));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new PremestiInventarUSobu());
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new IzmenaInventaraDijalog(MagacinFrame));
        }
    }
}
