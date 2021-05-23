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
    /// <summary>
    /// Interaction logic for BrisanjeRecenzijeUpravnik.xaml
    /// </summary>
    public partial class BrisanjeRecenzijeUpravnik : UserControl
    {
        private Frame frame = new Frame();
        private LekRevizija revizija;
        private MedicineReviewFileStorage reviewStorage = new MedicineReviewFileStorage();
        public BrisanjeRecenzijeUpravnik(Frame frameUpravnik, LekRevizija selectedItem)
        {
            InitializeComponent();
            frame = frameUpravnik;
            revizija = selectedItem;
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            reviewStorage.DeleteByIdMedicine(revizija.IdMedicine);
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
