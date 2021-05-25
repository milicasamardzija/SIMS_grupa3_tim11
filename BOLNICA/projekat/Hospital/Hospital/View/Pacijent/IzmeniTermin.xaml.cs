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
        public ObservableCollection<Appointment> appointmentList;
        public Appointment termin;
        public int index;
        public int idPatient; //id pacijenta koji je ulogovan
        private List<string> lista;
        private List<global::Doctor> lekari;
        private List<Appointment> termini;
        public ObservableCollection<Patient> pacijenti;


        public IzmeniTermin(ObservableCollection<Appointment> list, Appointment selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();

            appointmentList = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;

            lista = new List<string>();
            AppointmentFileStorage af = new AppointmentFileStorage("./../../../../Hospital/files/termini.json");
            termini = af.GetAll();
            lista.Add("");
            lista.Add("08:00");
            lista.Add("08:30");
            lista.Add("09:00");
            lista.Add("09:30");
            lista.Add("10:00");
            lista.Add("10:30");
            lista.Add("11:00");
            lista.Add("11:30");
            lista.Add("12:00");
            lista.Add("12:30");
            lista.Add("13:00");
            lista.Add("13:30");
            lista.Add("14:00");
            lista.Add("14:30");
            lista.Add("15:00");
            lista.Add("15:30");
            lista.Add("16:00");
            lista.Add("16:30");
            lista.Add("17:00");
            lista.Add("17:30");
            lista.Add("18:00");
            lista.Add("18:30");
            lista.Add("19:00");
            timeText.ItemsSource = lista;



      
            DoctorFileStorage df = new DoctorFileStorage();
             lekari= df.GetAll();
            doktor.ItemsSource = lekari;




            PatientFileStorage pacijent = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            List<Patient> sviPacijenti = pacijent.GetAll();
            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>(sviPacijenti);

            foreach (global::Doctor l in lekari)
            {
                if (l.jmbg == termin.Doctor.jmbg)
                    doktor.SelectedItem = l;
            }



            dateText.SelectedDate = selectedApp.DateTime;
            timeText.SelectedValue = selectedApp.DateTime.ToString("HH:mm");


            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, termin.DateTime.AddDays(-3));
            CalendarDateRange kalendar1 = new CalendarDateRange(termin.DateTime.AddDays(3), DateTime.MaxValue);

            dateText.BlackoutDates.Add(kalendar);
            dateText.BlackoutDates.Add(kalendar1);


        }

        public Patient getPatientFromFile()
        {
            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>(storage.GetAll());

            foreach (Patient patient in patients)
            {
                if (patient.Id == idPatient)
                {
                    ret = patient;
                    break; 
                }
            }
            return ret;
        }

          public Doctor getDoctorFromFile()
        {
            Doctor ret = new Doctor();

            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); 
            ret = doctors[0]; 
            return ret;
        }


        private void add_appointment(object sender, RoutedEventArgs e)
        {


            AppointmentFileStorage storage = new AppointmentFileStorage("./../../../../Hospital/files/termini.json");
            Patient patient = getPatientFromFile();
            global::Doctor doktor1 = (global::Doctor)doktor.SelectedItem;

            var item = timeText.SelectedItem;
            String t = item.ToString();
            String d = dateText.Text;
            DateTime dt = DateTime.Parse(d + " " + t);






            termin.DateTime = dt;
            termin.Doctor = doktor1;
            termin.Patient = patient;
            storage.DeleteById(termin.Id);
            storage.Save(termin);


            FunctionalityFileStorage funkcionalnosti = new FunctionalityFileStorage("./../../../../Hospital/files/count.json");
            Functionality funkcionalnost = new Functionality(DateTime.Now, idPatient, "izmena");
            funkcionalnosti.Save(funkcionalnost);


            this.Close();
        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void slobodni_doktori(object sender, RoutedEventArgs e)
        {
            foreach (Appointment t in termini)
            {

                string sat = t.DateTime.Hour.ToString();
                string minute = t.DateTime.Minute.ToString();
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
                    if (t.DateTime.Date == dateText.SelectedDate && (timeText.SelectedItem.Equals(izbaci)))
                    {
                        lekari.Remove(termin.Doctor);
                         doktor.ItemsSource = lekari;
                        doktor.SelectedIndex = lekari.Count() - 1;


                    }
                }
            }

        }

        private void potvrda(object sender, RoutedEventArgs e)
        {
            foreach (Appointment t in termini)
            {
                if (t.DateTime.Date == dateText.SelectedDate)
                {
                    string sat = t.DateTime.Hour.ToString();
                    string minute = t.DateTime.Minute.ToString();
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
                    timeText.ItemsSource = lista;
                }
                timeText.SelectedIndex = 0;
            }
        }


    }
}