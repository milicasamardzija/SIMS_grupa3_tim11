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
    /// Interaction logic for PrioritetDatum.xaml
    /// </summary>
    public partial class PrioritetDatum : Window

    {
        int id;
        private List<string> listStart;
        private List<string> listEnd;
        public PrioritetDatum(int idP)
        {
            InitializeComponent();
            id = idP;
            listStart = new List<string>();
            listEnd = new List<string>();
            DataContext = this;
             BlackOutDates();
            potvrdii.IsEnabled = false;
            date.IsEnabled = false;
          
            PrikazSlobodnihTermina.Visibility = Visibility.Hidden;
            InitializeStartTimes();
            endTime.IsEnabled = false;

            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> allPatients = storage.GetAll();
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>(allPatients);
            foreach (Patient patient in patients)
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.name + " " + patient.surname;
                }
            }
        }

        private void BlackOutDates()
        {
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);

        }

        private void InitializeStartTimes()
        {
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(20); tm = tm.AddMinutes(30))
            {
                listStart.Add(tm.ToString("HH:mm"));
            }
            startTime.ItemsSource = listStart;
        }

        private void InitializeEndTimes()
        {
            listEnd.Clear();
            DateTime danas = DateTime.Today;
            String datum = danas.ToShortDateString();
            DateTime pocetak = DateTime.Parse(datum + " " + startTime.SelectedItem.ToString()).AddMinutes(30);

            for (DateTime tm = pocetak; tm < danas.AddHours(20); tm = tm.AddMinutes(30))
            {
                listEnd.Add(tm.ToString("HH:mm"));
            }
            endTime.ItemsSource = listEnd;

        }

        private void startTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            endTime.IsEnabled = true;
            endTime.SelectedIndex = -1;
            InitializeEndTimes();
        }

        private void endTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date.IsEnabled = true;

        }


        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            //  Prioritet prioritet = new Prioritet(id);
            // prioritet.Show();
            this.Close();
        }

     

     

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowPacijent wp = new WindowPacijent(id);
            wp.Show();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

    



    private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
          
            PrikazSlobodnihTermina.Visibility = Visibility.Visible;
           // pretraziTermine();
        }


        public bool DoctorIsAvailable(DateTime pocetak, DateTime kraj) // proverava da li je lekar slobodan izmedju neka dva trenutka u vremenu
        {
            bool retVal = true;
            CheckupFileStorage cf = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> termini = cf.GetAll();
            foreach (Checkup termin in termini)
            {
                if (termin.IdDoctor.Equals(this))
                {
                    if (pocetak >= termin.Date && pocetak <= termin.Date.AddMinutes(15))
                    {
                        retVal = false;
                        break;
                    }
                    if (kraj >= termin.Date && kraj <= termin.Date.AddMinutes(15))
                    {
                        retVal = false;
                        break;
                    }
                    if (pocetak <= termin.Date && kraj >= termin.Date.AddMinutes(15))
                    {
                        retVal = false;
                        break;
                    }
                }
            }
            return retVal;
        }

        public bool PatientIsAvailable(DateTime pocetak, DateTime kraj) // proverava da li je lekar slobodan izmedju neka dva trenutka u vremenu
        {
            bool retVal = true;
            CheckupFileStorage cf = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> termini = cf.GetAll();
            foreach (Checkup termin in termini)
            {
                if (termin.IdPatient.Equals(id))
                {
                    if (pocetak >= termin.Date && pocetak <= termin.Date.AddMinutes(15))
                    {
                        retVal = false;
                        break;
                    }
                    if (kraj >= termin.Date && kraj <= termin.Date.AddMinutes(15))
                    {
                        retVal = false;
                        break;
                    }
                    if (pocetak <= termin.Date && kraj >= termin.Date.AddMinutes(15))
                    {
                        retVal = false;
                        break;
                    }
                }
            }
            return retVal;
        }
            private void pretraziTermine()
        {
            DateTime danas = DateTime.Today;
            String pocetak = startTime.SelectedItem.ToString();
            String kraj = endTime.SelectedItem.ToString();
            String datum = date.Text;

            DateTime pocetniDatum = DateTime.Parse(datum + " " + pocetak);
            DateTime krajnjiDatum = DateTime.Parse(datum + " " + kraj);

            DoctorFileStorage doctors = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            List<global::Doctor> ljekari = doctors.GetAll();
            foreach (global::Doctor lekar in ljekari)
            {
                for (DateTime tm = pocetniDatum; tm < krajnjiDatum; tm = tm.AddMinutes(15))
                {
                    DateTime end = tm.AddMinutes(15);
                  
                        if (DoctorIsAvailable(tm, end.AddMinutes(-1)) &&   PatientIsAvailable(tm, end.AddMinutes(-1)))
                        {
                            PrikazSlobodnihTermina.Items.Add(new SlobodniTermini(lekar, tm.ToString("HH:mm")));
                        }
                    

                }
            }



        }

        public class SlobodniTermini
        {
            public global::Doctor Ljekar { get; set; }
            public string AvailableTimes { get; set; }


            public SlobodniTermini()
            {

            }
            public SlobodniTermini(global::Doctor ljekarNovi, string times)
            {
                this.Ljekar = ljekarNovi;
                this.AvailableTimes = times;

            }



        }
        private void PrikazSlobodnihTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PrikazSlobodnihTermina.SelectedItem != null)
            {
                potvrdii.IsEnabled = true;
            }

        }




    }
}
