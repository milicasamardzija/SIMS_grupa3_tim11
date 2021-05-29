using Hospital.Controller;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DodajAnketu.xaml
    /// </summary>
    public partial class DodajAnketu : Window
    {

        public OcenjivanjeDoktora parent;
        public ObservableCollection<Checkup> obavljeniTermini;
        public Checkup termin;
        public int index;
        public int idPatient; //id pacijenta koji je ulogovan
        public string ime;
        private string lekar;
        SurveyController surveycontroler = new SurveyController();

        public DodajAnketu(ObservableCollection<Checkup> list, Checkup selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();
            obavljeniTermini = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;

            submit.IsEnabled = false;

            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> patients = storage.GetAll();
            ObservableCollection<Patient> allPatients =new  ObservableCollection<Patient>(patients);
            foreach (Patient patient in allPatients)
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.name + " " + patient.surname;
                }
            }

            DoctorFileStorage dstorage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            List<Doctor> doctors = dstorage.GetAll();
            foreach(Doctor d in doctors)
            {
                if(d.Id == termin.IdDoctor)
                {

                    ime = d.Name + " " + d.Surname;
                    doktor.Text = ime;

                }
            }


          
        }



        private void odustani(object sender, RoutedEventArgs e)
        {
            OcenjivanjeDoktora ocjeni = new OcenjivanjeDoktora(idPatient);

            this.Close();

        }

        private void posalji(object sender, RoutedEventArgs e)
        {
            SacuvanaAnketa poslato = new SacuvanaAnketa();
            poslato.Show();

          

            lekar = doktor.Text;
            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = surveycontroler.getAll().Count() + 1;
            Survey survey = new Survey(id, komentarisano, ocenjeno, null);

            surveycontroler.save(survey);
            obavljeniTermini.RemoveAt(index);
            this.Close();
        

        }

        private void ProvjeritiPopunjenostPolja()
        {
            if (komentar.Text != null && ocena.SelectedItem != null)
            {
                submit.IsEnabled = true;
            }
        }

        private void ocena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProvjeritiPopunjenostPolja();
        }

    }



}