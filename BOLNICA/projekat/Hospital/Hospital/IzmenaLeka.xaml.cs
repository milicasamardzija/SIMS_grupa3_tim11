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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmenaLeka.xaml
    /// </summary>
    public partial class IzmenaLeka : Window
    {

        public ObservableCollection<Medicine> listMedicine;
        public Medicine medicine;
        public int indexSelectedMedicine;

        public IzmenaLeka(ObservableCollection<Medicine> list, Medicine selectedMedicine, int medicineIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            listMedicine = list;
            medicine = selectedMedicine;
            indexSelectedMedicine = medicineIndex;

            nazivLText.SelectedText = Convert.ToString(selectedMedicine.Name);
            gramazaLText.SelectedText = Convert.ToString(selectedMedicine.Quantity);
            vrstaLText.SelectedText = Convert.ToString(selectedMedicine.Type);
            
        }

        public void addMedicines()
        {
            MedicineFileStorage medicineStorage = new MedicineFileStorage();
            foreach(Medicine medicine in medicineStorage.GetAll())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = medicine.Ingredients;
                combo1.Items.Add(item);
            }
        }

        public int generisiID()
        {
            int ret = 0;
            MedicineFileStorage storage = new MedicineFileStorage();
            List<Medicine> all = storage.GetAll();
            foreach (Medicine medicines in all)
            {
                foreach (Medicine medicine in all)
                {
                    if (ret == medicine.IdMedicine)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MedicineFileStorage medicineStorage = new MedicineFileStorage();
            medicine.Name = Convert.ToString(nazivLText.Text);
            medicine.Quantity = Convert.ToDouble(gramazaLText.Text);
            medicine.Type = Convert.ToString(vrstaLText.Text);
            List<int> idMed = new List<int>();
            List<int> idIngr = new List<int>();
            bool approvedMedicine = true;
            int idSelectedMedicine = generisiID();

            listMedicine[indexSelectedMedicine] = new Medicine(idSelectedMedicine, Convert.ToString(medicine.Name), Convert.ToDouble(medicine.Quantity),
                Convert.ToString(medicine.Type), idIngr, idMed, approvedMedicine);

            medicineStorage.DeleteById(idSelectedMedicine);
            medicineStorage.Save(medicine);
            this.Close();
        }
    }
}
