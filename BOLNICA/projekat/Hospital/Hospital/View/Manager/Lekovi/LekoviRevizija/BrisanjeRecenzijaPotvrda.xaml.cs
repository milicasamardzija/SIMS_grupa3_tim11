using Hospital.Controller;
using Hospital.DTO;
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

namespace Hospital.View.Manager.Lekovi.LekoviRevizija
{
   
    public partial class BrisanjeRecenzijaPotvrda : Window
    {
        private Frame frame;
        private ReviewDTO revision;
        private MedicineReviewController controller;
        public BrisanjeRecenzijaPotvrda(Frame frame, ReviewDTO revision)
        {
            InitializeComponent();
            this.frame = frame;
            this.revision = revision;
            this.controller = new MedicineReviewController();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            controller.deleteByIdMedicine(revision.IdMedicine);
            this.Close();
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
            this.Close();
        }
    }
}
