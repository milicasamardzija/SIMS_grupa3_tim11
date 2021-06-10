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
   
    public partial class PrioritetLekar : Window
    {

        public PatientDTO patient;

        private DoctorController doctorController; 

       public  ObservableCollection<PatientDTO> listPatient
        {
            get; set;
        }
       public  ObservableCollection<DoctorDTO> listDoctors
        {
            get; set;
        }
        public PrioritetLekar(ObservableCollection<PatientDTO> list, PatientDTO selectedPatient)
        {
            InitializeComponent();
            this.DataContext = this;
            patient=selectedPatient; //imam pacijenta kome zakazujem 
            doctorController = new DoctorController();
            listPatient = list;
            listDoctors = loadJson();// ucitava se lista svih lekara 

        }

        private ObservableCollection<DoctorDTO> loadJson()
        {
           
             ObservableCollection<DoctorDTO> doctors = new ObservableCollection<DoctorDTO>(doctorController.getAll());
            return doctors;

        }

        private void getDoctorTerms(object sender, RoutedEventArgs e)
        {
            if ((DoctorDTO)doktori.SelectedItem != null)
            {
                SacuvajLekara terms = new SacuvajLekara(listDoctors, (DoctorDTO)doktori.SelectedItem, patient); //poslala sam informaciju o doktoru, moram i o ranijem pacijentu 
                terms.Show();

            } else
            {
                MessageBoxResult result = MessageBox.Show("Niste odabrali lekara!");
            }
        }

        private void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
