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
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmenaLeka.xaml
    /// </summary>
    public partial class IzmenaLeka : Window
    {
        public ObservableCollection<IngredientDTO> DataIngredient { get; set; }
        public ObservableCollection<MedicineDTO> DataMedicine { get; set; }
        
        public MedicineController controller = new MedicineController();
        public IngredientController ingredientController = new IngredientController();

        public ObservableCollection<MedicineDTO> medicineList;
        public MedicineDTO medicine;
        public int indexMedicine;

        public IzmenaLeka(ObservableCollection<MedicineDTO> list, MedicineDTO selectedMedicine, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            medicineList = list;
            medicine = selectedMedicine;
            indexMedicine = selectedIndex;
            DataIngredient = new ObservableCollection<IngredientDTO>(ingredientController.getAll());
            DataMedicine = new ObservableCollection<MedicineDTO>(controller.getAll());

            nazivLText.SelectedText = Convert.ToString(selectedMedicine.Name);
            gramazaLText.SelectedText = Convert.ToString(selectedMedicine.Quantity);
            vrstaLText.SelectedText = Convert.ToString(selectedMedicine.Type);
        }

        public int generateIdMedicine()
        {
            int returnMedicine = 0;
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> all = new ObservableCollection<Medicine>(storage.GetAll());
            foreach (Medicine medicine in all)
            {
                foreach (Medicine medicines in all)
                {
                    if (returnMedicine == medicines.Id)
                    {
                        ++returnMedicine;
                        break;
                    }
                }
            }
            return returnMedicine;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<int> ingredients = new List<int>();
            List<int> medicines = new List<int>();

            medicineList[indexMedicine] = new MedicineDTO(generateIdMedicine(), Convert.ToString(nazivLText.Text), Convert.ToDouble(gramazaLText.Text),
                Convert.ToString(vrstaLText.Text), ingredients, medicines, true);

            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
