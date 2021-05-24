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
        public ObservableCollection<Appointment> obavljeniTermini;
        public Appointment termin;
        public int index;
        public int idPatient; //id pacijenta koji je ulogovan
        public string ime;
      
        
        

        
       private string lekar;

        public DodajAnketu(ObservableCollection<Appointment> list, Appointment selectedApp, int selectedIndex, int idP)
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

            ime = termin.Doctor.name + " " + termin.Doctor.surname;
            doktor.Text = ime;


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

            SurveyFileStorage sveAnkete = new SurveyFileStorage("./../../../../Hospital/files/ankete.json");

            lekar = doktor.Text;
            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = sveAnkete.GetAll().Count() + 1;

            Survey novaAnketa = new Survey(id, komentarisano, ocenjeno, lekar,termin.Id);

            sveAnkete.Save(novaAnketa);
            obavljeniTermini.RemoveAt(index);



            this.Close();
         // parent.UpdateTable();

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