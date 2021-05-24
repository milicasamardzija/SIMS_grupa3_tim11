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

namespace Hospital
{
    public partial class LekoviPrikazUpravnik : UserControl
    {
        private Frame frameUprvanik;
        public ObservableCollection<Medicine> MedicineList { get; set; }
        public LekoviPrikazUpravnik(Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            frameUprvanik = frame;
            MedicineList = loadJason();
        }

        public ObservableCollection<Medicine> loadJason()
        {
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> ret = new ObservableCollection<Medicine>();

            foreach (Medicine medicine in storage.GetAll())
            {
                if (medicine.Approved)
                {
                    ret.Add(medicine);
                }
            }

            return ret;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
              frameUprvanik.NavigationService.Navigate(new DodavanjeLekaRevizija(frameUprvanik));
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (ListaLekova.SelectedItem != null)
            {
                frameUprvanik.NavigationService.Navigate(new IzmenaLekaUpravnik((Medicine)ListaLekova.SelectedItem, frameUprvanik, MedicineList));
            } else
            {
                frameUprvanik.NavigationService.Navigate(new LekoviPrikazUpravnik(frameUprvanik));
            }
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (ListaLekova.SelectedItem != null)
            {
                LekoviFrame.NavigationService.Navigate(new BrisanjeLekaRevizijaUpravnik((Medicine)ListaLekova.SelectedItem, frameUprvanik));
            }
            else
            {
                frameUprvanik.NavigationService.Navigate(new LekoviPrikazUpravnik(frameUprvanik));
            }
        }
        private void prikazRevizije(object sender, RoutedEventArgs e)
        {
            frameUprvanik.NavigationService.Navigate(new LekoviRevizijaUpravnik(frameUprvanik));
        }
    }
}
