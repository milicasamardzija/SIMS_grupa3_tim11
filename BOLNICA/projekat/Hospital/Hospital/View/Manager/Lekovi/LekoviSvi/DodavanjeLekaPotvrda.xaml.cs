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
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital.View.Manager.Lekovi.LekoviSvi
{
    public partial class DodavanjeLekaPotvrda : Window
    {
        private Frame frame = new Frame();
        private ReviewDTO revision;
        private MedicineController controller = new MedicineController();
        public DodavanjeLekaPotvrda(Frame frameLekovi, ReviewDTO revision)
        {
            InitializeComponent();
            frame = frameLekovi;
            this.revision = revision;
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            controller.approveMedicine(revision);
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
            this.Close();
        }
    }
}
