using Hospital.FileStorage.Interfaces;
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
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    public partial class BrisanjeRecenzijeUpravnik : UserControl
    {
        private Frame frame;
        private ReviewDTO revision;
        private MedicineReviewController controller;
        public BrisanjeRecenzijeUpravnik(Frame frame, ReviewDTO revision)
        {
            InitializeComponent();
            this.frame = frame;
            this.revision = revision;
            this.controller = new MedicineReviewController();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            controller.deleteByIdMedicine(revision.IdMedicine);
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
