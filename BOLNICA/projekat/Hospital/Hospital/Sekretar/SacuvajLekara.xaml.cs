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
  
    public partial class SacuvajLekara : Window
    {
        Patient selectedPatient; //pacijentu kome zakazujemo termin 
        Doctor doctor; //doktor koji je izabran
        public int idD; //id tog lekara za checkup
        public int idP; //id tog pacijenta za checkup
        public int idRoom; //id sobe u koju cu da zakazem 
        public DateTime day; //dan koji ce da izabere 
        public DateTime time; //vreme koje ce da podesi
        public ObservableCollection<Patient> listPatient;
        public ObservableCollection<Doctor> listDoctor;
        public SacuvajLekara(ObservableCollection<Doctor> list, Doctor selectedDoctor, Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            selectedPatient = patient; //je l mi treba foreach bas da ga nadjem ili mogu ovako?
            idP = patient.PatientId;
            doctor = selectedDoctor;
            idD = selectedDoctor.DoctorId;

            listDoctor = list;
            
        }
        public void SaveCheckup(object sender, RoutedEventArgs e)
        {
            
        }
       public void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
