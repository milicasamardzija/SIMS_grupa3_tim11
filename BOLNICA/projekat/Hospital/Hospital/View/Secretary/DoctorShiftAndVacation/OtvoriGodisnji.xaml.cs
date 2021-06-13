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
    /// Interaction logic for OtvoriGodisnji.xaml
    /// </summary>
    public partial class OtvoriGodisnji : Window
    {

        public ObservableCollection<DoctorDTO> sviLekari { get; set; }
        public DoctorController doctorController;
        public DoctorShiftController shiftController;
        public OtvoriGodisnji()
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

        private void izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            if (lekari.SelectedItem != null && datumOd.SelectedDate != null && datumDo.SelectedDate != null)
            {
                int ret = shiftController.addFreeShift((DoctorDTO)lekari.SelectedItem, (DateTime)datumOd.SelectedDate, (DateTime)datumDo.SelectedDate);
                MessageBox.Show("Ovom lekaru je ostalo jos " + ret + " slobodnih dana");
            } else
            {
                MessageBox.Show("Morate popuniti polja!");
            }
        }
    }
}
