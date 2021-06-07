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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for AnketaPage.xaml
    /// </summary>
    public partial class AnketaPage : Page
    {
        
        public ObservableCollection<Checkup> obavljeniTermini;
        public Checkup termin;
        public int index;
        public int idPatient; //id pacijenta koji je ulogovan
        public string ime;
        private string lekar;
        SurveyController surveycontroler;
        PatientController patientcontroller;
        private SurveyDTO survey = new SurveyDTO();

        public SurveyDTO Survey
        {
            get { return survey; }
            set { survey = value; }
        }
        private PocetnaPacijent parent;

        public AnketaPage(PocetnaPacijent p,ObservableCollection<Checkup> list, Checkup selectedApp, int selectedIndex)
        {
            InitializeComponent();
            parent = p;
            obavljeniTermini = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = p.id;
            surveycontroler = new SurveyController();
            patientcontroller = new PatientController();

            submit.IsEnabled = false;


            DoctorFileStorage dstorage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            List<Doctor> doctors = dstorage.GetAll();
            foreach (Doctor d in doctors)
            {
                if (d.Id == termin.IdDoctor)
                {

                    //   ime = d.Name + " " + d.Surname;
                    ime = "Branislava Borunov";
                    doktor.Text = ime;

                }
            }

            ime = "Branislava Borunov";
            doktor.Text = ime;

        }



        private void odustani(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new OcenaPage(parent);

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

            surveycontroler.save(Survey);
            obavljeniTermini.RemoveAt(index);
            parent.startWindow.Content = new OcenaPage(parent);


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