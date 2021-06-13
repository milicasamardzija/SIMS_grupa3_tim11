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
    /// Interaction logic for Evidencija.xaml
    /// </summary>
    public partial class Evidencija : Window
    {
        public ObservableCollection<MedicineDTO> MedicineList { get; set; }
        public MedicineController controllerMedicine = new MedicineController();

        public Evidencija()
        {
            InitializeComponent();
            this.DataContext = this;
            MedicineList = new ObservableCollection<MedicineDTO>(controllerMedicine.getAll());
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IzmenaLeka medicineEdit = new IzmenaLeka(MedicineList, (MedicineDTO)ListMedicines.SelectedItem, ListMedicines.SelectedIndex);
            medicineEdit.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            LekoviCekajuReviziju medicineForReview = new LekoviCekajuReviziju();
            medicineForReview.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
