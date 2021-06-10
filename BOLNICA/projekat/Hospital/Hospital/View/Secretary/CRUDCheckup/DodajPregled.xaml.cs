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

namespace Hospital.Sekretar
{
    /// <summary>
    /// Interaction logic for DodajPregled.xaml
    /// </summary>
    public partial class DodajPregled : Window
    {

        public PatientController patientController;
        public ObservableCollection<PatientDTO> listPatients
        {
            get;
            set;
        }
        public DodajPregled()
        {
            InitializeComponent();
            this.DataContext = this;
            patientController = new PatientController();
            listPatients = loadAllPatients();
           
        }


        private ObservableCollection<PatientDTO> loadAllPatients()
        {
            ObservableCollection<PatientDTO> patients = new ObservableCollection<PatientDTO>(patientController.loadAllPatients());
            return patients;

        }
        private void SaveDoctorBtn(object sender, RoutedEventArgs e)
        {  if ((PatientDTO)sviPacijenti.SelectedItem != null)
            {
                PrioritetLekar doctorPriority = new PrioritetLekar(listPatients, (PatientDTO)sviPacijenti.SelectedItem);
                doctorPriority.Show();
            } else
            {
                MessageBox.Show("Niste izabrali pacijenta!");
            }

        }
        private void SaveDateBtn(object sender, RoutedEventArgs e)
        {
            if ((PatientDTO)sviPacijenti.SelectedItem != null)
            {
                PrioritetDatum datePriority = new PrioritetDatum(listPatients, (PatientDTO)sviPacijenti.SelectedItem);
                datePriority.Show();
            } else
            {
                MessageBox.Show("Niste izabrali pacijenta!");
            }
        }

      
    }
}
