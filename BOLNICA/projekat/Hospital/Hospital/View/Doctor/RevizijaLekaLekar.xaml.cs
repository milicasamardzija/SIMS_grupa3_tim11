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

        public ObservableCollection<Review> reviewList;
        public Review medicineReview;
        public int indexReview;

        public RevizijaLekaLekar(ObservableCollection<Review> list, Review selectedReview, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            reviewList = list;
            medicineReview = selectedReview;
            indexReview = selectedIndex;

            textNaziv.SelectedText = Convert.ToString(medicineReview.Name);
            textTipLeka.SelectedText = Convert.ToString(medicineReview.MedicineType);
            textTipRevizije.SelectedText = Convert.ToString(medicineReview.ReviewType);

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int generisiID()
        {
            int ret = 0;
            MedicineReviewIFileStorage storageMedicineReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            List<MedicineReview> allMedicineReview = storageMedicineReview.GetAll();
            foreach (MedicineReview medicineReview in allMedicineReview)
            {
                foreach (MedicineReview medicineReviews in allMedicineReview)
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
            MedicineIFileStorage storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            List<Medicine> allMedicines = storageMedicine.GetAll();
            foreach (Medicine medicine in allMedicines)
            {
                foreach (Medicine medicines in allMedicines)
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
            reviewList[indexReview] = new Review(medicineReview.Name, medicineReview.MedicineType, medicineReview.ReviewType, true, generateID(), generisiID());
            this.Close();
        }
    }
}
