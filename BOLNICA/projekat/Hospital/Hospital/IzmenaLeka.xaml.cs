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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmenaLeka.xaml
    /// </summary>
    public partial class IzmenaLeka : Window
    {

        public ObservableCollection<Ingredient> DataIngredient { get; set; }
        public ObservableCollection<Medicine> DataMedicine { get; set; }

        public ObservableCollection<Medicine> medicineList;
        public Medicine medicine;
        public int indexMedicine;

        public IzmenaLeka(ObservableCollection<Medicine> list, Medicine selectedMedicine, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            DataIngredient = loadIngredient();
            DataMedicine = loadMedicine();
            medicineList = list;
            selectedMedicine = medicine;
            selectedIndex = indexMedicine;
            /*
            nazivLText.SelectedText = Convert.ToString(selectedMedicine.Name);
            gramazaLText.SelectedText = Convert.ToString(selectedMedicine.Quantity);
            vrstaLText.SelectedText = Convert.ToString(selectedMedicine.Type);*/
           
        }

        public ObservableCollection<Ingredient> loadIngredient()
        {
            IngredientsFileStorage storageIngredient = new IngredientsFileStorage();
            ObservableCollection<Ingredient> ingredient = new ObservableCollection<Ingredient>(storageIngredient.GetAll());
            ObservableCollection<Ingredient> returnIngredient = new ObservableCollection<Ingredient>();

            foreach(Ingredient ingredients in ingredient)
            {
                returnIngredient.Add(ingredients);
            }
            return returnIngredient;
        }

        public ObservableCollection<Medicine> loadMedicine()
        {
            MedicineFileStorage storageMedicine = new MedicineFileStorage();
            ObservableCollection<Medicine> medicine = new ObservableCollection<Medicine>(storageMedicine.GetAll());
            ObservableCollection<Medicine> returnMedicine = new ObservableCollection<Medicine>();

            foreach (Medicine medicines in medicine)
            {
                returnMedicine.Add(medicines);
            }
            return returnMedicine;
        }

        public int generisiID()
        {
            int ret = 0;
            MedicineFileStorage storage = new MedicineFileStorage();
            ObservableCollection<Medicine> all = new ObservableCollection<Medicine>(storage.GetAll());
            foreach (Medicine medicine in all)
            {
                foreach (Medicine medicines in all)
                {
                    if (ret == medicines.IdMedicine)
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
            //MedicineFileStorage storageMedicine = new MedicineFileStorage();
            this.Close();
        }
    }
}
