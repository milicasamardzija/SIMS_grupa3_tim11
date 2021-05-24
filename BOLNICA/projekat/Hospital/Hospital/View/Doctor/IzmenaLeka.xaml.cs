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
using Hospital.FileStorage.Interfaces;

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
            medicineList = list;
            medicine = selectedMedicine;
            indexMedicine = selectedIndex;
            DataIngredient = loadIngredient();
            DataMedicine = loadMedicine();

            nazivLText.SelectedText = Convert.ToString(selectedMedicine.Name);
            gramazaLText.SelectedText = Convert.ToString(selectedMedicine.Quantity);
            vrstaLText.SelectedText = Convert.ToString(selectedMedicine.Type);

           
        }

        public ObservableCollection<Ingredient> loadIngredient()
        {
            IngredientsIFileStorage storage = new IngredientsFileStorage("./../../../../Hospital/files/storageIngredients.json");
            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>(storage.GetAll());
            ObservableCollection<Ingredient> ret = new ObservableCollection<Ingredient>();
            foreach (Ingredient ingredient in ingredients)
            {
                ret.Add(ingredient);
            }
            return ret;
        }

        public ObservableCollection<Medicine> loadMedicine()
        {
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>(storage.GetAll());
            ObservableCollection<Medicine> ret = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicines)
            {
                ret.Add(medicine);
            }
            return ret;
        }

        public int generisiID()
        {
            int ret = 0;
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> all = new ObservableCollection<Medicine>(storage.GetAll());
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<int> ingredients = new List<int>();
            List<int> medicines = new List<int>();
 
            medicineList[indexMedicine] = new Medicine(generisiID(), Convert.ToString(nazivLText.Text), Convert.ToDouble(gramazaLText.Text),
                Convert.ToString(vrstaLText.Text), ingredients, medicines, true);
            this.Close();
        }
    }
}
