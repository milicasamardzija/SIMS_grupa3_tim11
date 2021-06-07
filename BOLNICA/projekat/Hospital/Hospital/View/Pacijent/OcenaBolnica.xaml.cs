using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for OcenaBolnica.xaml
    /// </summary>
    public partial class OcenaBolnica : Page
    {
        int id;


        SurveyController surveycontroler;
        PatientController patientcontroller;
        private PocetnaPacijent parent;
        private SurveyDTO survey = new SurveyDTO();

        public SurveyDTO Survey
        {
            get { return survey; }
            set { survey = value; }
        }
        public OcenaBolnica(PocetnaPacijent p)
        {
            InitializeComponent();
            id = p.id;
            surveycontroler = new SurveyController();
            patientcontroller = new PatientController();
            parent = p;


           
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
            


            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = surveycontroler.getAll().Count() + 1;

             // Survey survey = new Survey(id, komentarisano, ocenjeno, null);

            surveycontroler.save(Survey);
            parent.startWindow.Content = new OcenaPage(parent);

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new OcenaPage(parent);
        }

     
    }
}
