using Hospital.Controller;
using Hospital.Prikaz;
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
    public partial class DodavanjeLekaUpravnik : UserControl
    {
        private Frame frame = new Frame();
        private Review revision;
        private MedicineController controller = new MedicineController();
      
        public DodavanjeLekaUpravnik(Frame frameLekovi, Review selectedRevision)
        {
            InitializeComponent();
            frame = frameLekovi;
            revision = selectedRevision;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            controller.approveMedicine(revision);
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
