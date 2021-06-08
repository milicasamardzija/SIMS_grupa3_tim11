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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for PacijentPPage.xaml
    /// </summary>
    public partial class PacijentPPage : Page
    {
        private static PocetnaPacijent parent;
        public PacijentPPage(PocetnaPacijent p)
        {
            InitializeComponent();
            parent = p;
        }
        private void Odjava(object sender, RoutedEventArgs e)
        {
            Logovanje mw = new Logovanje();
            mw.Show();
           // this.Close();
        }

        private void prikaz_termina(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new PreglediP(parent);
          
        }

        private void klik_na_obavestenja(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new ObavestenjaPage(parent);
        }

        private void klik_na_karton(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new KartonPage(parent);
        }

        private void klik_na_ocenjivanje(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new OcenaPage(parent);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new TerapijaP(parent);

        }
    }
}
    
