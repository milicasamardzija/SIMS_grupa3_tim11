using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
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

namespace Hospital
{
    public partial class LekoviPrikazUpravnik : UserControl
    {
        private Frame frame;
        public ObservableCollection<MedicineDTO> medicines { get; set; }
        private MedicineController controller;
        public LekoviPrikazUpravnik(Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.controller = new MedicineController();
            this.medicines = new ObservableCollection<MedicineDTO>(controller.getAll());
        }
        
        private void dodaj(object sender, RoutedEventArgs e)
        {
              frame.NavigationService.Navigate(new DodavanjeLekaRevizija(frame));
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (ListaLekova.SelectedItem != null)
            {
                frame.NavigationService.Navigate(new IzmenaLekaUpravnik((MedicineDTO)ListaLekova.SelectedItem, frame, medicines));
            } else
            {
                frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
            }
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (ListaLekova.SelectedItem != null)
            {
                LekoviFrame.NavigationService.Navigate(new BrisanjeLekaRevizijaUpravnik((MedicineDTO)ListaLekova.SelectedItem, frame));
            }
            else
            {
                frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
            }
        }
        private void prikazRevizije(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviRevizijaUpravnik(frame));
        }
    }
}
