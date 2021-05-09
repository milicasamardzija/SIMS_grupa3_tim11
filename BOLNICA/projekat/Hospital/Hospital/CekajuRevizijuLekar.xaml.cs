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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for CekajuRevizijuLekar.xaml
    /// </summary>
    public partial class CekajuRevizijuLekar : Window
    {

        public ObservableCollection<LekRevizija> ReviewMedicineList { get; set; }
        private Frame frame = new Frame();
        public CekajuRevizijuLekar(Frame frameUpravnik)
        {
            InitializeComponent();
            ListReview.ItemsSource = loadJF();
            frame = frameUpravnik;

        }

        public ObservableCollection<LekRevizija> loadJF()
        {   
            MedicineFileStorage storageMedicine = new MedicineFileStorage();
            MedicineReviewFileStorage storageMedicineReview = new MedicineReviewFileStorage();
            ObservableCollection<LekRevizija> ret = new ObservableCollection<LekRevizija>();
            foreach(MedicineReview mr in storageMedicineReview.GetAll())
            {
                ret.Add(mr);
            }
            return ret;
            /*
            foreach(Medicine medicine in storageMedicine.GetAll())
            {
                foreach(MedicineReview medicineReview in storageMedicineReview.GetAll())
                {
                    if(medicineReview.IdMedicine == medicine.IdMedicine)
                    {
                        ret.Add(new LekRevizija(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.IdMedicine, medicineRewiev.IdMedicineReview));
                        break;
                    }
                }
            }
            return ret;*/

            
            /*
            foreach (Medicine medicine in storageMedicine.GetAll())
            {
                if (!medicine.Approved)
                {
                    foreach (MedicineReview medicineRewiev in storageMedicineReview.GetAll())
                    {
                        if (medicineRewiev.IdMedicine == medicine.IdMedicine)
                        {
                            ret.Add(new LekRevizija(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.IdMedicine, medicineRewiev.IdMedicineReview));
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
                        if (medicineRewiev.IdMedicine == medicine.IdMedicine)
                        {
                            ret.Add(new LekRevizija(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.IdMedicine, medicineRewiev.IdMedicineReview));
                            break;
                        }
                    }
                }
            }

            return ret;*/
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RevizijaLekaLekar rll = new RevizijaLekaLekar();
            rll.Show();
        }
    }
}
