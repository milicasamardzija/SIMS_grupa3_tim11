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
using System.Collections.ObjectModel;
using System.IO;
using Hospital.Model;
using Hospital.Prikaz;
using Hospital.FileStorage.Interfaces;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for RevizijaLekaLekar.xaml
    /// </summary>
    public partial class RevizijaLekaLekar : Window
    {

        public ObservableCollection<LekRevizija> reviewList;
        public LekRevizija lekRevizija;
        public int indexReview;

        public RevizijaLekaLekar(ObservableCollection<LekRevizija> list, LekRevizija selectedReview, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            reviewList = list;
            lekRevizija = selectedReview;
            indexReview = selectedIndex;

            textNaziv.SelectedText = Convert.ToString(lekRevizija.Name);
            textTipLeka.SelectedText = Convert.ToString(lekRevizija.MedicineType);
            textTipRevizije.SelectedText = Convert.ToString(lekRevizija.ReviewType);
            //textLekar.SelectedText = getDoctor();
            //textKomentar.SelectedText = Convert.ToString(lekRevizija.)

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int generisiID()
        {
            int ret = 0;
            MedicineReviewIFileStorage storage = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            List<MedicineReview> all = storage.GetAll();
            foreach (MedicineReview mr in all)
            {
                foreach (MedicineReview medicineReviews in all)
                {
                    if (ret == medicineReviews.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public int generateID()
        {
            int ret = 0;
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            List<Medicine> all = storage.GetAll();
            foreach (Medicine medicine in all)
            {
                foreach (Medicine medicines in all)
                {
                    if (ret == medicines.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            reviewList[indexReview] = new LekRevizija(lekRevizija.Name, lekRevizija.MedicineType, lekRevizija.ReviewType, true, generateID(), generisiID());
            this.Close();
        }
    }
}
