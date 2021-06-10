using Hospital.View.Secretary.AppOrganisation;
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

      //  public Page blogg;

        public Nalozi()
        {
            InitializeComponent();

            ProfilSekretara ps = new ProfilSekretara(this);
            frameS.Navigate(ps);

        }

        private void pacijenti(object sender, RoutedEventArgs e)
        {
            Pacijenti p = new Pacijenti();
            frameS.Navigate(p);

        }

        private void blog(object sender, RoutedEventArgs e)
        {
            SvaObavestenja b = new SvaObavestenja();
            frameS.Navigate(b);
        }
       
       
      private void profil(object sender, RoutedEventArgs e)
        {
            ProfilSekretara ps = new ProfilSekretara(this);
            frameS.Navigate(ps);
        }

        private void analitika(object sender, RoutedEventArgs e)
        {
            Analitika a = new Analitika();
            frameS.Navigate(a);
        }
        private void feedback(object sender, RoutedEventArgs e)
        {
            FeedbackSekretar a = new FeedbackSekretar();
            frameS.Navigate(a);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
