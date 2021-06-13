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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Secretary.DoctorShiftAndVacation
{
    /// <summary>
    /// Interaction logic for Shifts.xaml
    /// </summary>
    public partial class Shifts : Page
    {

        public ObservableCollection<DoctorDTO> prvaSmena { get; set; }
        public ObservableCollection<DoctorDTO> drugaSmena { get; set; }
        public ObservableCollection<DoctorDTO> trecaSmena { get; set; }
        public ObservableCollection<DoctorDTO> pauzaSmena { get; set; }
        public ObservableCollection<DoctorDTO> godisnji { get; set; }
        public DoctorController doctorController;
        public DoctorShiftController shiftController;
        public Shifts()
        {
            InitializeComponent();
            this.DataContext = this;
            doctorController = new DoctorController();
            shiftController = new DoctorShiftController();
            shiftController.updateShift();
            prvaSmena = loadPrvaSmena();
            drugaSmena = loadDrugaSmena();
            trecaSmena = loadTrecaSmena();
            pauzaSmena = loadPauza();
            godisnji = loadGodisnji();
            

        }

        private ObservableCollection<DoctorDTO> loadPauza()
        {
            ObservableCollection<DoctorDTO> pauza = new ObservableCollection<DoctorDTO>(doctorController.doctorInShift(ShiftType.pause));
            return pauza;
        }

        private ObservableCollection<DoctorDTO> loadGodisnji()
        {
            ObservableCollection<DoctorDTO> godisnji = new ObservableCollection<DoctorDTO>(doctorController.doctorInShift(ShiftType.free));
            return godisnji;
        }

        private ObservableCollection<DoctorDTO> loadTrecaSmena()
        {
            ObservableCollection<DoctorDTO> treca = new ObservableCollection<DoctorDTO>(doctorController.doctorInShift(ShiftType.third));
            return treca;
        }

        public ObservableCollection<DoctorDTO> loadPrvaSmena()
        {
            ObservableCollection<DoctorDTO> prva = new ObservableCollection<DoctorDTO>(doctorController.doctorInShift(ShiftType.first));
            return prva;
        }
        public ObservableCollection<DoctorDTO> loadDrugaSmena()
        {
            ObservableCollection<DoctorDTO> druga = new ObservableCollection<DoctorDTO>(doctorController.doctorInShift(ShiftType.second));
            return druga;
        }

        private void promeniSmenu(object sender, RoutedEventArgs e)
        {
            PromeniSmenu promeni = new PromeniSmenu();
            promeni.Show();

        }
        private void nadjiSmenu(object sender, RoutedEventArgs e)
        {
            PronadjiSmenu nadji = new PronadjiSmenu();
            nadji.Show();

        }
        private void otvoriGodisnji(object sender, RoutedEventArgs e)
        {
            OtvoriGodisnji godisnji = new OtvoriGodisnji();
            godisnji.Show();

        }

      
    }
}
