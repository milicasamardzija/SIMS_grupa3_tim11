using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DodajTermin.xaml
    /// </summary>
    public partial class DodajTermin : Window
    {

        public ObservableCollection<Appointment> appointmentList;
        public int idPatient; //id pacijenta koji je ulogovan
        private List<string> lista;
        private List<global::Doctor> lekari;

        public DodajTermin(ObservableCollection<Appointment> applist, int idP)
        {
            InitializeComponent();
            appointmentList = applist;
            idPatient = idP;


            lista = new List<string>();
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
            lista.Add("15:30");
            lista.Add("16:00");
            lista.Add("16:30");
            lista.Add("17:00");
            lista.Add("17:30");
            lista.Add("18:00");
            lista.Add("18:30");
            lista.Add("19:00");
            time.ItemsSource = lista;





            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);
            DoctorFileStorage df = new DoctorFileStorage();
            lekari = df.GetAll();
            lekar.IsEnabled = false;
            time.IsEnabled = false;
        }

        public Patient getPatientFromFile()
        {
            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage();
            ObservableCollection<Patient> patients = storage.GetAll();

            foreach (Patient patient in patients) //prolaz kroz sve pacijente u fajlu
            {
                if (patient.PatientId == idPatient) //pronalazi pacijenta sa id-jem ulogovanog pacijenta
                {
                    ret = patient;
                    break; //kada ga nadje izlazi iz petlje
                }
            }
            return ret;
        }

        //ova fija uvek ubacuje jednog istog doktora, kada se u tabeli prikaze doktor i kada on bude moga da se izabere onda se ova fija treba izmeniti da bi se nasao bas izabrani doktor iz fajla i ubacio u termin
        public Doctor getDoctorFromFile()
        {
            Doctor ret = new Doctor();

            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); //cita listu doktora iz fajla
            ret = doctors[0]; //uzima prvog u listi(jedinog)

            return ret;
        }

        private void add_appointment(object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage storage = new AppointmentFileStorage();
            Patient patient = getPatientFromFile();

            global::Doctor doktor = (global::Doctor)lekar.SelectedItem;
            var item = time.SelectedItem;
            String t = item.ToString();
            String d = date.Text;
            DateTime dt = DateTime.Parse(d + " " + t);
            int id = storage.GetAll().Count();


            Appointment newapp = new Appointment(id, dt, 30, doktor, patient);

            storage.Save(newapp);
            appointmentList.Add(newapp);

            this.Close();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (prioritetCombo.SelectedIndex == 0)
            {
                time.IsEnabled = true;

                global::Doctor doktor = (global::Doctor)lekar.SelectedItem;

                AppointmentFileStorage storage = new AppointmentFileStorage();
                List<Appointment> termini = storage.GetAll();

                foreach (Appointment t in termini)
                {
                    if (t.Doctor.jmbg.Equals(doktor.jmbg))
                    {
                        if ((t.dateTime.Date == date.SelectedDate))
                        {
                            string sat = t.dateTime.Hour.ToString();
                            string minute = t.dateTime.Minute.ToString();
                            string izbaci;
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
                                izbaci = "0q" + sat + ":" + minute;
                            }
                            else
                            {

                                izbaci = sat + ":" + minute;
                            }

                            if (brojac2 == 1)
                            {
                                izbaci = izbaci + "0";

                            }
                            Debug.WriteLine(izbaci);
                            lista.Remove(izbaci);


                        }
                    }

                }

                time.ItemsSource = lista;
            }
            else
            {
                lekar.IsEnabled = true;
                AppointmentFileStorage storage = new AppointmentFileStorage();
                List<Appointment> termini = storage.GetAll();
                foreach (Appointment t in termini)
                {
                    string sat = t.dateTime.Hour.ToString();
                    string minute = t.dateTime.Minute.ToString();
                    string izbaci;
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

                    if ((t.dateTime.Date == date.SelectedDate) && (time.SelectedItem.Equals(izbaci)))
                    {
                        {

                            Debug.WriteLine(izbaci);
                            lekari.Remove(t.Doctor);
                            lekar.ItemsSource = lekari;
                            lekar.SelectedIndex = lekari.Count() - 1;



                        }


                    }

                }

                lekar.ItemsSource = lekari;

            }
        }


        private void prioritetCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (prioritetCombo.SelectedIndex == 0)
            {
                lekar.IsEnabled = true;
                lekar.ItemsSource = lekari;
            }
            else
            {
                time.IsEnabled = true;
                date.IsEnabled = false;
                time.ItemsSource = lista;
            }
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date.IsEnabled = true;
        }

    }
}

