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
    /// Interaction logic for OceniteBolnicu.xaml
    /// </summary>
    public partial class OceniteBolnicu : Window
    {

        int id;
      

        SurveyController surveycontroler;
        PatientController patientcontroller;
        private SurveyDTO survey = new SurveyDTO();
    
        public SurveyDTO Survey
        {
            get { return survey; }
            set { survey = value; }
        }
        public OceniteBolnicu(int idP)
        {
            InitializeComponent();
            id = idP;
            surveycontroler = new SurveyController();
            patientcontroller = new PatientController();


           
            foreach (PatientDTO patient in patientcontroller.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }
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




        private void posalji(object sender, RoutedEventArgs e)
        {
            SacuvanaAnketa surveys = new SacuvanaAnketa();
            surveys.Show();
            this.Close();
         
           
         
            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = surveycontroler.getAll().Count() + 1;

            SurveyDTO survey = new SurveyDTO(id, komentarisano, ocenjeno, null);

            surveycontroler.save(survey);

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
