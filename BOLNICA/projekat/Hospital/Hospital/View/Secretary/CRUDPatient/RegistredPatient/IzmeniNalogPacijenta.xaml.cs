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
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;
using Hospital.Controller;

namespace Hospital
{

    public partial class IzmeniNalogPacijenta : Window { 

        public ObservableCollection<PatientDTO> listPatient;
        public PatientController patientContoller;
        //public ObservableCollection<MedicalRecord> listRecord;
        public PatientDTO patient;
        public PatientDTO Selected 
        { get { return patient; }
            set { patient = value; } 
        }
        public int index;
       // public MedicalRecord record;

        public int id;
        public IzmeniNalogPacijenta(ObservableCollection<PatientDTO> list, PatientDTO selectedPatient, int sel)
        {
           InitializeComponent();
            this.DataContext = this;
            listPatient = list;
            patient = selectedPatient;
            patientContoller = new PatientController();
            index = sel;

    
        }

        private void izmenaPacijentaB(object sender, RoutedEventArgs e)
        {
            
            patientContoller.izmeniPacijenta(patient);
            this.Close();
            
         

        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
