using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Prikaz;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hospital.View.Manager.Lekovi.LekoviRevizija;

namespace Hospital
{
    public partial class LekoviRevizijaUpravnik : UserControl
    {
        public ObservableCollection<ReviewDTO>MedicineReviewList { get; set; }
        private Frame frame;
        private MedicineReviewController medicineController;
        public LekoviRevizijaUpravnik(Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            medicineController = new MedicineReviewController();
            MedicineReviewList = new ObservableCollection<ReviewDTO>(medicineController.getAll());
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {   if(ListaLekovaRevizija.SelectedItem != null)
               LekoviRevizijaFrame.NavigationService.Navigate(new DodavanjeLekaUpravnik(frame, (ReviewDTO)ListaLekovaRevizija.SelectedItem));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (ListaLekovaRevizija.SelectedItem != null)
                LekoviRevizijaFrame.NavigationService.Navigate(new BrisanjeLekaUpravnik(frame,(ReviewDTO)ListaLekovaRevizija.SelectedItem));
        }

        private void prikaziReviziju(object sender, SelectionChangedEventArgs e)
        {
            if (ListaLekovaRevizija.SelectedItem != null)
                LekoviRevizijaFrame.Navigate(new LekoviPrikazRevizijeUpravnik((ReviewDTO)ListaLekovaRevizija.SelectedItem));
        }

        private void izbrisiRezenziju(object sender, RoutedEventArgs e)
        {
            if (ListaLekovaRevizija.SelectedItem != null)
                // LekoviRevizijaFrame.NavigationService.Navigate(new BrisanjeRecenzijeUpravnik(frame, (ReviewDTO)ListaLekovaRevizija.SelectedItem));
            {
                BrisanjeRecenzijaPotvrda brisanje =
                    new BrisanjeRecenzijaPotvrda(frame, (ReviewDTO) ListaLekovaRevizija.SelectedItem);
                brisanje.Show();
            }
        }

        private void unazad(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void posaljiOpet(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new IzmenaLekaRevizija((ReviewDTO)ListaLekovaRevizija.SelectedItem,frame));
        }
    }
}
