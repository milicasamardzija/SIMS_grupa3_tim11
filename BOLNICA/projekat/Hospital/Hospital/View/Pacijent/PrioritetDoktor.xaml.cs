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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for PrioritetDoktor.xaml
    /// </summary>
    public partial class PrioritetDoktor : Window
    {
        CheckupController checkupController;
        FunctionalityController functionalityController;
        PatientController patientController;
        private List<global::Doctor> lekari;
        private List<string> availableTimes;
        private List<CheckupDTO> termini;
        public ObservableCollection<CheckupDTO> appointmentList;
        int id;


        public PrioritetDoktor(ObservableCollection<CheckupDTO> applist, int idP)
        {
            InitializeComponent();
            id = idP;
            appointmentList = applist;
            termini = new List<CheckupDTO>();

            checkupController = new CheckupController();
            functionalityController = new FunctionalityController();
            patientController = new PatientController();


          
            foreach (PatientDTO patient in patientController.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }

            DoctorFileStorage df = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            lekari = df.GetAll();
            lekar.ItemsSource = lekari;

            potvrdii.IsEnabled = false;
            date.IsEnabled = false;

            timelabel.Visibility = Visibility.Hidden;
            BlackOutDates();
            times.Visibility = Visibility.Hidden;
            availableTimes = new List<string>();
        }


        private void BlackOutDates()
        {
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);

        }


        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ZakaziTermin();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {

         
            this.Close();
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            Prioritet prioritet = new Prioritet(appointmentList, id);
            prioritet.Show();
            this.Close();
        }

        private void ljekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date.IsEnabled = true;

        }

        private void times_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            potvrdii.IsEnabled = true;
        }

        private void pretraziTermine()
        {
            times.Items.Clear();
            availableTimes.Clear();
            termini.Clear();
           
            DoctorFileStorage doctors = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
            global::Doctor doktor = (global::Doctor)lekar.SelectedItem;



            foreach (CheckupDTO t in checkupController.getAll())
            {
                foreach (Doctor d in doctors.GetAll())
                {
                    if (t.IdDoctor == d.Id)
                    {
                        if (d.Jmbg.Equals(doktor.Jmbg))
                        {
                            if (t.Date.Date.Equals(date.SelectedDate))
                            {
                                termini.Add(t);
                            }
                        }
                    }
                }
                if (id == t.IdPatient && t.Date.Date.Equals(date.SelectedDate))
                {


                    termini.Add(t);


                }
            }

            List<CheckupDTO> terminiBezDuplikata = termini.Distinct().ToList();
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(20); tm = tm.AddMinutes(30))
            {
                bool slobodno = true;
                foreach (CheckupDTO termin in terminiBezDuplikata)
                {
                    DateTime start = DateTime.Parse(termin.Date.ToString("HH:mm"));
                    DateTime end = DateTime.Parse(termin.Date.AddMinutes(termin.Duration).ToString("HH:mm"));
                    if (tm >= start && tm < end)
                    {
                        slobodno = false;
                    }
                }
                if (slobodno)
                    availableTimes.Add(tm.ToString("HH:mm"));

                if (date.SelectedDate == danas)
                {
                    if (tm < DateTime.Now.AddMinutes(30))
                    {
                        availableTimes.Remove(tm.ToString("HH:mm"));
                    }
                }

            }
            foreach (string time in availableTimes)
            {
                times.Items.Add(time);
            }


        }

        private void ZakaziTermin()
        {
 
            global::Doctor doktor = (global::Doctor)lekar.SelectedItem;
            if (times.SelectedIndex != -1)
            {
                var item = times.SelectedItem;
                String t = item.ToString();
                String d = date.Text;
                DateTime dt = DateTime.Parse(d + " " + t);
                int idG = checkupController.getAll().Count();

                CheckupDTO checkup = new CheckupDTO(idG, doktor.Id, id, dt, 1, 0);

                checkupController.save(checkup);
                appointmentList.Add(checkup);


                FunctionalityDTO funkcionalnost = new FunctionalityDTO(id, DateTime.Now, id, "dodavanje");
                functionalityController.save(funkcionalnost);

                this.Close();
                WindowPacijent wp = new WindowPacijent(id);
                wp.Show();

            }
        }
        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            timelabel.Visibility = Visibility.Visible;
            times.Visibility = Visibility.Visible;
            pretraziTermine();
        }
    }
}