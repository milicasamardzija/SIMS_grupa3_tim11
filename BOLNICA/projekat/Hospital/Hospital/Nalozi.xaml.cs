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
    /// Interaction logic for Nalozi.xaml
    /// </summary>
    public partial class Nalozi : Window
    {

        public Nalozi(Page blogGlavni)
        {
            InitializeComponent();
            blogg = blogGlavni;
        }


        private void KreirajButton(object sender,  RoutedEventArgs e)
        {
            KreirajNalog noviNalog = new KreirajNalog();
            noviNalog.ShowDialog();
        }
        private void kreirajGButton(object sender, RoutedEventArgs e) {

            KreirajGuestNalog noviGNalog = new KreirajGuestNalog();
            noviGNalog.ShowDialog();
        }
 

        private void izbrisiButton(object sender, RoutedEventArgs e)
        {
            IzbrisiNalogPacijenta izbrisiNalog = new IzbrisiNalogPacijenta();
            izbrisiNalog.ShowDialog();
        }

        private void prikaziPacijenteButton(object sender, RoutedEventArgs e)
        {
            PrikaziPacijente prikaz = new PrikaziPacijente();
            prikaz.ShowDialog();
        }
    

        private void prikaziGPacijenteButton(object sender, RoutedEventArgs e)
        {
            var prikazG = new PrikaziGuestPacijente();
            prikazG.ShowDialog();
        }
       
        private void blog(object sender, RoutedEventArgs e)
        {
            UredjivanjeBloga blog = new UredjivanjeBloga();
            blog.ShowDialog();
        }
    }
}
