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

namespace Hospital.View.Manager.Lekovi.LekoviRevizija
{
    public partial class BrisanjeLekaPotvrda : Window
    {
        private Frame frame;
        private ReviewDTO revision;
        private MedicineController controller;
        public BrisanjeLekaPotvrda(Frame frame, ReviewDTO revision)
        {
            InitializeComponent();
            this.frame = frame;
            this.revision = revision;
            this.controller = new MedicineController();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            controller.deleteMedicine(revision.IdMedicine);
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
