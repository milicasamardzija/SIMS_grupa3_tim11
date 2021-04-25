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
    public partial class Pacijenti : Page
    {
        public Pacijenti()
        {
            InitializeComponent();
        }

        private void prikaziPacijente(object sender, RoutedEventArgs e)
        {
            PrikaziPacijente prikaz = new PrikaziPacijente();
            prikaz.ShowDialog();
        }
        private void prikaziGPacijenteButton(object sender, RoutedEventArgs e)
        {
            var prikazG = new PrikaziGuestPacijente();
            prikazG.ShowDialog();
        }
        private void KreirajButton(object sender, RoutedEventArgs e)
        {
            KreirajNalog noviNalog = new KreirajNalog();
            noviNalog.ShowDialog();
        }
        private void kreirajGButton(object sender, RoutedEventArgs e)
        {

            KreirajGuestNalog noviGNalog = new KreirajGuestNalog();
            noviGNalog.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
