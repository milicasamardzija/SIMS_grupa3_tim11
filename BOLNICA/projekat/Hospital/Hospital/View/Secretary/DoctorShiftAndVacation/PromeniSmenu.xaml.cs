using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
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
    /// Interaction logic for PromeniSmenu.xaml
    /// </summary>
    public partial class PromeniSmenu : Window
    {
        public ObservableCollection<DoctorDTO> sviLekari { get; set; }
        public DoctorController doctorController;
        public DoctorShiftController shiftController;
        public PromeniSmenu()
        {
            InitializeComponent();
            this.DataContext = this;
            doctorController = new DoctorController();
            shiftController = new DoctorShiftController();
            sviLekari = loadAllDoctors();
            dodajSmene();


        }


        public ObservableCollection<DoctorDTO> loadAllDoctors()
        {
            ObservableCollection<DoctorDTO> allDoctors = new ObservableCollection<DoctorDTO>(doctorController.getAll());
            return allDoctors;
        }

        private void izadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sacuvajBtn(object sender, RoutedEventArgs e)
        {
            if(datumPicker.SelectedDate != null && lekari.SelectedItem != null)
            { 
                ScheduleShiftDTO newShift = new ScheduleShiftDTO((DateTime)datumPicker.SelectedDate, (ShiftType)smene.SelectedValue);
                shiftController.changeShift2((DoctorDTO)lekari.SelectedItem, newShift);
                MessageBox.Show("Zakazali ste smenu!");
                
            } else
            {
                MessageBox.Show("Niste odabrali potrebne podatke!");
            }
        }

        public void dodajSmene()
        {

            smene.ItemsSource = Enum.GetValues(typeof(ShiftType));

        }


    }
}
