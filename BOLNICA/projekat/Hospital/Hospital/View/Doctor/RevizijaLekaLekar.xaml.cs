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

        public int generateIdMedicineReview()
        {
            int retMedicineReview = 0;
            MedicineReviewIFileStorage storageMedicineReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            List<MedicineReview> allMedicineReview = storageMedicineReview.GetAll();
            foreach (MedicineReview medicineReview in allMedicineReview)
            {
                foreach (MedicineReview medicineReviews in allMedicineReview)
                {
                    if (retMedicineReview == medicineReviews.Id)
                    {
                        ++retMedicineReview;
                        break;
                    }
                }
            }
            return retMedicineReview;
        }

        public int generateIdMedicine()
        {
            int retMedicine = 0;
            MedicineIFileStorage storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            List<Medicine> allMedicine = storageMedicine.GetAll();
            foreach (Medicine medicine in allMedicine)
            {
                foreach (Medicine medicines in allMedicine)
                {
                    if (retMedicine == medicines.Id)
                    {
                        ++retMedicine;
                        break;
                    }
                }
            }
            return retMedicine;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            reviewList[indexReview] = new Review(medicineReview.Name, medicineReview.MedicineType, medicineReview.ReviewType, true,
                generateIdMedicine(), generateIdMedicineReview());

            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
