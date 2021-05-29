using Hospital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for IzmeniTermin.xaml
    /// </summary>
    public partial class IzmeniTermin : Window
    {
        public ObservableCollection<Checkup> appointmentList;
        public Checkup termin;
        public int index;
        public int idPatient; //id pacijenta koji je ulogovan
        private List<string> lista;
        private List<global::Doctor> lekari;
        private List<Checkup> termini;
        public ObservableCollection<Patient> pacijenti;
        private List<string> availableTimes;


        public IzmeniTermin(ObservableCollection<Checkup> list, Checkup selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();

            appointmentList = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;

            lista = new List<string>();
            CheckupFileStorage af = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            termini = af.GetAll();
            
            time.ItemsSource = lista;




            DoctorFileStorage df = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
            lekari = df.GetAll();
            lekar.ItemsSource = lekari;




            PatientFileStorage pacijent = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> sviPacijenti = pacijent.GetAll();
            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>(sviPacijenti);

            foreach (global::Doctor l in lekari)
            {
                if (l.Id == termin.IdDoctor)
                {
                  
                      lekar.SelectedItem = l;
                }
            }



            date.SelectedDate = selectedApp.Date;
            time.SelectedValue = selectedApp.Date.ToString("HH:mm");


            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, termin.Date.AddDays(-3));
            CalendarDateRange kalendar1 = new CalendarDateRange(termin.Date.AddDays(3), DateTime.MaxValue);

            date.BlackoutDates.Add(kalendar);
            date.BlackoutDates.Add(kalendar1);


        }


        private void LoadTimes()
        {

            DateTime datum;
            global::Doctor l = (global::Doctor)lekar.SelectedItem;
            if (date.SelectedDate != null)
            {
                datum = DateTime.Parse(date.Text);
            }
            else
            {
                datum = DateTime.Now;
            }

            availableTimes = new List<string>();
            List<Checkup> termini = new List<Checkup>();
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(20); tm = tm.AddMinutes(15))
            {
                bool slobodno = true;
                foreach (Checkup termin in termini)
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

            time.ItemsSource = availableTimes;
        }


        private void CheckAvailableTimes()
        {

            DateTime datum;
            global::Doctor l = (global::Doctor)lekar.SelectedItem;
            if (date.SelectedDate != null)
            {
                datum = DateTime.Parse(date.Text);
            }
            else
            {
                datum = DateTime.Now;
            }

            CheckupFileStorage cfs = new CheckupFileStorage("./ .. / .. / .. / .. / Hospital / files / storageCheckup.json") ;
            availableTimes = new List<string>();
            List<Checkup> termini = new List<Checkup>();
            if (lekar.SelectedItem != null && date.SelectedDate != null)

            {
                foreach (Checkup termin in cfs.GetAll())
                {
                    if (l.Id == termin.IdDoctor)
                    {
                        if (termin.Date.Date.Equals(date.SelectedDate))
                        {
                            termini.Add(termin);
                        }
                    }

                    if (idPatient == termin.IdPatient)
                    {
                        if (termin.Date.Date.Equals(date.SelectedDate))
                        {
                            termini.Add(termin);
                        }
                    }


                }
            }

            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(20); tm = tm.AddMinutes(15))
            {
                bool slobodno = true;
                foreach (Checkup termin in termini)
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


            }

            time.ItemsSource = availableTimes;
            if (availableTimes.Contains(termin.Date.ToString("HH:mm")))
            {
                time.SelectedItem = termin.Date.ToString("HH:mm");
            }


        }


        private void add_appointment(object sender, RoutedEventArgs e)
        {


            CheckupFileStorage storage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            global::Doctor doktor1 = (global::Doctor)lekar.SelectedItem;

            var item = time.SelectedItem;
            String t = item.ToString();
            String d = date.Text;
            DateTime dt = DateTime.Parse(d + " " + t);

            termin.IdDoctor = doktor1.Id;
            termin.IdPatient = idPatient;
            termin.Date = dt;
            storage.DeleteById(termin.Id);
            storage.Save(termin);


            FunctionalityFileStorage funkcionalnosti = new FunctionalityFileStorage("./../../../../Hospital/files/count.json");
            Functionality funkcionalnost = new Functionality(DateTime.Now, idPatient, "izmena");
            funkcionalnosti.Save(funkcionalnost);


            this.Close();
        }


        private void setEnabledButtonSubmit()
        {
            if (lekar.SelectedItem != null && date.SelectedDate != null && time.SelectedItem != null)
            {
                potvrdi.IsEnabled = true;
            }
            else
            {
                odustanii.IsEnabled = false;
            }
        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void slobodni_doktori(object sender, RoutedEventArgs e)
        {
            foreach (Checkup t in termini)
            {

                string sat = t.Date.Hour.ToString();
                string minute = t.Date.Minute.ToString();
                string izbaci = "";
                int brojac1 = 0;
                int brojac2 = 0;
                foreach (char s in sat)
                {
                    ++brojac1;

                }
                foreach (char s in minute)
                {
                    ++brojac2;
                }
                if (brojac1 == 1)
                {
                    izbaci = "0" + sat + ":" + minute;
                }
                else
                {

                    izbaci = sat + ":" + minute;
                }

                if (brojac2 == 1)
                {
                    izbaci = izbaci + "0";

                }

                if (t.Doctor.jmbg.Equals(termin.Doctor.jmbg))
                {
                    if (t.Date.Date == date.SelectedDate && (time.SelectedItem.Equals(izbaci)))
                    {
                        lekari.Remove(termin.Doctor);
                        lekar.ItemsSource = lekari;
                        lekar.SelectedIndex = lekari.Count() - 1;


                    }
                }
            }

        }

        private void potvrda(object sender, RoutedEventArgs e)
        {
            foreach (Checkup t in termini)
            {
                if (t.Date.Date == date.SelectedDate)
                {
                    string sat = t.Date.Hour.ToString();
                    string minute = t.Date.Minute.ToString();
                    string izbaci = "";
                    int brojac1 = 0;
                    int brojac2 = 0;
                    foreach (char s in sat)
                    {
                        ++brojac1;

                    }
                    foreach (char s in minute)
                    {
                        ++brojac2;
                    }
                    if (brojac1 == 1)
                    {
                        izbaci = "0" + sat + ":" + minute;
                    }
                    else
                    {

                        izbaci = sat + ":" + minute;
                    }

                    if (brojac2 == 1)
                    {
                        izbaci = izbaci + "0";

                    }

                    lista.Remove(izbaci);
                    time.ItemsSource = lista;
                }
                time.SelectedIndex = 0;
            }
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lekar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void odustani(object sender, RoutedEventArgs e)
        {

        }
    }
}