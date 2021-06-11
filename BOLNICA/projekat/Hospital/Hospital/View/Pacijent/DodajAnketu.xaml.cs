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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DodajAnketu.xaml
    /// </summary>
    public partial class DodajAnketu : Window
    {

      
        SurveyController surveycontroler;
        PatientController patientcontroller;
        DoctorController doctorcontroller;
        private SurveyDTO survey = new SurveyDTO();
        
    
        public SurveyDTO Survey
        {
            get { return survey; }
            set { survey = value; }
        }
     
        public ObservableCollection<CheckupDTO> obavljeniTermini;
        public CheckupDTO termin;
        public int index;
        public int idPatient;
        public string ime;
     
        public DodajAnketu(ObservableCollection<CheckupDTO> list, CheckupDTO selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();
            obavljeniTermini = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;
            surveycontroler = new SurveyController();
            patientcontroller = new PatientController();
            doctorcontroller = new DoctorController();
            submit.IsEnabled = false;


            foreach (PatientDTO patient in patientcontroller.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }

         
            foreach (DoctorDTO d in doctorcontroller.getAll())
            {
                if (d.Id == termin.IdDoctor)
                {
                   
                    ime = d.Name + " " + d.Surname;
                    doktor.Text = ime;

                }
            }



        }

 
        private void posalji(object sender, RoutedEventArgs e)
        {
          
            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = surveycontroler.getAll().Count() + 1;
            SurveyDTO survey = new SurveyDTO(id, komentarisano, ocenjeno, ime);

            surveycontroler.save(survey);
            obavljeniTermini.RemoveAt(index);
            this.Close();
            SacuvanaAnketa poslato = new SacuvanaAnketa();
            poslato.Show();



        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            OcenjivanjeDoktora ocjeni = new OcenjivanjeDoktora(idPatient);

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