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
using Hospital.Model;
using Hospital.Prikaz;
using Hospital.FileStorage.Interfaces;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for LekoviCekajuReviziju.xaml
    /// </summary>
    public partial class LekoviCekajuReviziju : Window
    {
        public ObservableCollection<Review> ListMedicineReview { get; set; }

        public LekoviCekajuReviziju()
        {
            InitializeComponent();
            this.DataContext = this;
            ListMedicineReview = loadMedicineReview();
        }

        public ObservableCollection<Review> loadMedicineReview()
        {
            MedicineIFileStorage storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            MedicineReviewIFileStorage storageMedicineReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            ObservableCollection<Review> returnMedicineReview = new ObservableCollection<Review>();

            foreach (Medicine medicine in storageMedicine.GetAll())
            {
                if (!medicine.Approved)
                {
                    foreach (MedicineReview medicineRewiev in storageMedicineReview.GetAll())
                    {
                        if (medicineRewiev.IdMedicine == medicine.Id)
                        {
                            returnMedicineReview.Add(new Review(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.Id, medicineRewiev.Id));
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
                            returnMedicineReview.Add(new Review(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.Id, medicineRewiev.Id));
                            break;
                        }
                    }
                }
            }

            return returnMedicineReview;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RevizijaLekaLekar reviewMedicine = new RevizijaLekaLekar(ListMedicineReview, (Review)ReviewMedicineList.SelectedItem, ReviewMedicineList.SelectedIndex);
            reviewMedicine.Show();
        }
    }
}
