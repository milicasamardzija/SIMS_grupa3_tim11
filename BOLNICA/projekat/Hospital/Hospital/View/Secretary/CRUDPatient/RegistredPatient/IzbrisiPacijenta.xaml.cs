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

namespace Hospital
{

    public partial class IzbrisiPacijenta : Window
    {
        public ObservableCollection<PatientDTO> listPatient;
        public PatientDTO selectedPatient;
        public int index;
        
        public PatientController patientController;
        public IzbrisiPacijenta(ObservableCollection<PatientDTO> list, PatientDTO patient, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            listPatient = list;
            selectedPatient = patient;
            index = selectedIndex;
            patientController = new PatientController();
        }

        private void potvrdiB(object sender, RoutedEventArgs e)
        {
           
            patientController.deletePatient(selectedPatient);
            listPatient.RemoveAt(index);
            this.Close();
           
        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
