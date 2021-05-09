using Hospital.Controller;
using Hospital.Model;
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
    public partial class BrisanjeLekaUpravnik : UserControl
    {
        private Frame frame = new Frame();
        private LekRevizija revision;
        private MedicineFileStorage storage = new MedicineFileStorage();
        private MedicineReviewFileStorage reviewStorage = new MedicineReviewFileStorage();
   
        public BrisanjeLekaUpravnik(Frame frameLekovi, LekRevizija selectedRevision)
        {
            InitializeComponent();
            frame = frameLekovi;
            revision = selectedRevision;
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            storage.DeleteById(revision.IdMedicine);
            reviewStorage.DeleteByIdMedicine(revision.IdMedicine);
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
