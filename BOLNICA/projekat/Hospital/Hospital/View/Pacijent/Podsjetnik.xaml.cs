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
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Podsjetnik.xaml
    /// </summary>
    public partial class Podsjetnik : Window
    {
        PatientController patientController;
        CheckupController checkupController;
        AnamnesisController anamnesisController;
        int id;
        private List<string> termini;
        private List<string> beleska;
        private String danas;
        private String datum;



        public Podsjetnik(int idP)
        {
            InitializeComponent();
            id = idP;

            patientController = new PatientController();
            checkupController = new CheckupController();
            anamnesisController = new AnamnesisController();
            beleska = new List<string>();
            termini = new List<string>();


            foreach (PatientDTO patient in patientController.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }




           
            danas = DateTime.Now.Date.ToString();

            
            List<Note> notes = new List<Note>();
            foreach (Anamnesis a in anamnesisController.getAll())
            {
                if (a.NotesForAnamnesis != null)
                {
                    foreach (Note n in a.NotesForAnamnesis)
                    { if (n.IsSetReminder == true)
                        {
                            if(DateTime.Now>=n.StartDate && DateTime.Now<=n.EndDate) 
                            beleska.Add(n.description.ToString());
                        }
                    }
                }
            }
            beleske.ItemsSource = beleska;

          
            foreach (CheckupDTO appointment in checkupController.getAll())
            {

                if (appointment.IdPatient == id)
                {
                    danas = DateTime.Now.Day.ToString();
                    datum = appointment.Date.AddDays(-1).Day.ToString();


                    if (danas == datum)
                    {
                        termini.Add("Sutra imate zakazan pregled.Provjerite kalendar.");
                    }
                }
            }

           
            obavestenja.ItemsSource = termini;

        }


        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
            PocetnaPacijent pocetna = new PocetnaPacijent(id);
            pocetna.Show();        }
    }
}
