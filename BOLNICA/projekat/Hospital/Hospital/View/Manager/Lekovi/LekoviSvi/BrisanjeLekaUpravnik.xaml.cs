using Hospital.Controller;
using Hospital.DTO;
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

namespace Hospital
{
    public partial class BrisanjeLekaUpravnik : UserControl
    {
        private Frame frame;
        private ReviewDTO revision;
        private MedicineController controller;

        public BrisanjeLekaUpravnik(Frame frame, ReviewDTO revision)
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
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
