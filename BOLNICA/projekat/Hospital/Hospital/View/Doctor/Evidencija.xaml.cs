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
    /// Interaction logic for Evidencija.xaml
    /// </summary>
    public partial class Evidencija : Window
    {
        public ObservableCollection<Medicine> MedicineList { get; set; }
        
        public Evidencija()
        {
            InitializeComponent();
            this.DataContext = this;
            MedicineList = loadJsFile();
        }

        public ObservableCollection<Medicine> loadJsFile()
        {
            MedicineFileStorage storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>(storageMedicine.GetAll());
            ObservableCollection<Medicine> returnMedicine = new ObservableCollection<Medicine>();
            
            foreach(Medicine medicine in medicines)
            {
                returnMedicine.Add(medicine);
            }
            return returnMedicine;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IzmenaLeka changeMedicine = new IzmenaLeka(MedicineList, (Medicine)ListMedicines.SelectedItem, ListMedicines.SelectedIndex);
            changeMedicine.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            LekoviCekajuReviziju reviewForMedicine = new LekoviCekajuReviziju();
            reviewForMedicine.Show();
        }
    }
}
