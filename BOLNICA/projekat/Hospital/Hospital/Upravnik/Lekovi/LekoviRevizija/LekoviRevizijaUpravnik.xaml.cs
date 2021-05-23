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

namespace Hospital
{
    public partial class LekoviRevizijaUpravnik : UserControl
    {
        public ObservableCollection<LekRevizija> MedicineReviewList { get; set; }
        private Frame frame = new Frame();
        public LekoviRevizijaUpravnik(Frame frameUpravnik)
        {
            InitializeComponent();
            this.DataContext = this;
            MedicineReviewList = loadJson();
            frame = frameUpravnik;
        }

        public ObservableCollection<LekRevizija> loadJson()
        {
            MedicineIFileStorage storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            MedicineReviewIFileStorage storageMedicineReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            ObservableCollection<LekRevizija> ret = new ObservableCollection<LekRevizija>();

            foreach (Medicine medicine in storageMedicine.GetAll())
            {
                if (!medicine.Approved)
                {
                    foreach (MedicineReview medicineRewiev in storageMedicineReview.GetAll()) 
                    {
                        if (medicineRewiev.IdMedicine == medicine.Id)
                        {
                            ret.Add(new LekRevizija(medicine.Name,medicine.Type,medicineRewiev.TypeReview,medicineRewiev.Done, medicine.Id, medicineRewiev.Id));
                            break;
                        }
                    }
                }
            }

            foreach (Medicine medicine in storageMedicine.GetAll())
            {
                if (medicine.Delete)
                {
                    foreach (MedicineReview medicineRewiev in storageMedicineReview.GetAll())
                    {
                        if (medicineRewiev.IdMedicine == medicine.Id)
                        {
                            ret.Add(new LekRevizija(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.Id, medicineRewiev.Id));
                            break;
                        }
                    }
                }
            }

            return ret;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {   if(ListaLekovaRevizija.SelectedItem != null)
                LekoviRevizijaFrame.NavigationService.Navigate(new DodavanjeLekaUpravnik(frame, (LekRevizija)ListaLekovaRevizija.SelectedItem));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (ListaLekovaRevizija.SelectedItem != null)
                LekoviRevizijaFrame.NavigationService.Navigate(new BrisanjeLekaUpravnik(frame,(LekRevizija)ListaLekovaRevizija.SelectedItem));
        }

        private void prikaziReviziju(object sender, SelectionChangedEventArgs e)
        {
            if (ListaLekovaRevizija.SelectedItem != null)
                LekoviRevizijaFrame.Navigate(new LekoviPrikazRevizijeUpravnik((LekRevizija)ListaLekovaRevizija.SelectedItem));
        }

        private void izbrisiRezenziju(object sender, RoutedEventArgs e)
        {
            if (ListaLekovaRevizija.SelectedItem != null)
                LekoviRevizijaFrame.NavigationService.Navigate(new BrisanjeRecenzijeUpravnik(frame, (LekRevizija)ListaLekovaRevizija.SelectedItem));
        }

        private void unazad(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }
    }
}
