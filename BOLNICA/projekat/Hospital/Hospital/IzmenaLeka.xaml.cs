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


            //listMedicine[indexSelectedMedicine] = new Medicine()
        }
    }
}
