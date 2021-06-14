using Hospital.Controller;
using Hospital.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.View.Secretary.DoctorShiftAndVacation
{
    /// <summary>
    /// Interaction logic for PronadjiSmenu.xaml
    /// </summary>
    public partial class PronadjiSmenu : Window
    {
        public ObservableCollection<DoctorDTO> sviLekari { get; set; }
        public DoctorController doctorController;
        public DoctorShiftController shiftController;
        public PronadjiSmenu()
        {
            InitializeComponent();
            this.DataContext = this;
            doctorController = new DoctorController();
            shiftController = new DoctorShiftController();
            sviLekari = loadAllDoctors();

        }
        public ObservableCollection<DoctorDTO> loadAllDoctors()
        {
            ObservableCollection<DoctorDTO> allDoctors = new ObservableCollection<DoctorDTO>(doctorController.getAll());
            return allDoctors;
        }

        private void nadjiSmenu(object sender, RoutedEventArgs e)
        {
            if (datumPicker.SelectedDate != null && lekari.SelectedItem != null)
            {
                String smena = shiftController.PredictDoctorShift((DoctorDTO)lekari.SelectedItem, (DateTime)datumPicker.SelectedDate);
              
                MessageBoxResult result =  MessageBox.Show("Smena za izabranog lekara navedenog datuma je " + smena);
               
            } else
            {
                MessageBox.Show("Niste odabrali datum");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
