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

namespace Hospital.Sekretar
{
    
    public partial class PrikaziPreglede : Window
    {

        public Doctor doctor;  //da nadjem lekara i ispisem ga 
        public Patient patient; //da nadjem pacijenta i ispisem i njega
        public PatientFileStorage pfs;
        public DoctorFileStorage dfs;
       public  ObservableCollection<Checkup> listCheckups
        { 
            get;
            set; 
        }

       


        public PrikaziPreglede()
        {
            InitializeComponent();
            this.DataContext = this;
            listCheckups = loadJsonCheckups();
            

        }

       public ObservableCollection<Checkup> loadJsonCheckups()
        {
            CheckupFileStorage cfs = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            ObservableCollection<Checkup> ch = new ObservableCollection<Checkup>(cfs.GetAll()); 
               
            return ch;

        }
        private ObservableCollection<Doctor> loadDoctors() {
            DoctorFileStorage dfs = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>(dfs.GetAll());

            return doctors;
        }
        private ObservableCollection<Patient> loadPatients()
        {
            PatientFileStorage pfs = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>(pfs.GetAll());

            return patients;
        }

        private void AddNewCheckup(object sender, RoutedEventArgs e)
        {
            DodajPregled newCheckup = new DodajPregled();
            newCheckup.Show();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            ObrisiPregled del = new ObrisiPregled(listCheckups, (Checkup)sviPregledi.SelectedItem, sviPregledi.SelectedIndex);
            del.Show();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            IzmeniPregled edit = new IzmeniPregled(listCheckups, (Checkup)sviPregledi.SelectedItem, sviPregledi.SelectedIndex);
        edit.Show();
          }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
