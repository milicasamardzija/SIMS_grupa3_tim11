using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
using Hospital.View.Pacijent;
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

        private CheckupController checkupcontroller = new CheckupController();
        private FunctionalityController funkcionalitycontroller = new FunctionalityController();
        private PatientController patientcontroller = new PatientController();

        public ObservableCollection<Checkup> appointmentList;
        public int idPatient; //id pacijenta koji je ulogovan
        private List<string> lista;
        private List<global::Doctor> lekari;
        public int count1;
        private const int trajanje = 30;
        private List<string> dostupnoVrijeme;

        public DodajTermin(ObservableCollection<Checkup> applist, int idP)
        {
            InitializeComponent();
            appointmentList = applist;
            idPatient = idP;

           
            List<PatientDTO> patients = patientcontroller.getAll();
            foreach (PatientDTO patient in patients)
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }

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
            time.ItemsSource = lista;





            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);
            DoctorFileStorage df = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            lekari = df.GetAll();
            lekar.ItemsSource = lekari;

            

        }

        
      

        private void add_appointment(object sender, RoutedEventArgs e)
        {

          
         global::Doctor doktor = (global::Doctor)lekar.SelectedItem;
            if (time.SelectedIndex != -1)
            {
                var item = time.SelectedItem;
                String t = item.ToString();
                String d = date.Text;
                DateTime dt = DateTime.Parse(d + " " + t);
                int id = checkupcontroller.getAll().Count();


                Checkup checkup = new Checkup(id, doktor.Id, idPatient, dt, 1, 0);
                checkupcontroller.save(checkup);
                appointmentList.Add(checkup);

              
                Functionality funkcionalnost = new Functionality(DateTime.Now, idPatient, "dodavanje");
                funkcionalitycontroller.save(funkcionalnost);

                this.Close();
            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




        private void CalculateStartAndEnd(out DateTime start, out DateTime end)
        {
            if (time.SelectedItem != null && date.SelectedDate != null)
            {
                String timeSelected = time.SelectedItem.ToString();
                String dateSelected = date.Text;

                start = DateTime.Parse(dateSelected + " " + timeSelected);
                end = start.AddMinutes(trajanje);
            }
            else
            {
                start = DateTime.Now;
                end = DateTime.Now;
            }
        }

        private void UpdateComponents()
        {
            DateTime start;
            DateTime end;

            CalculateStartAndEnd(out start, out end);

          //  EnabledDugme();

            CheckAvailableTimes();





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

            dostupnoVrijeme = new List<string>();
            List<Checkup> termini = new List<Checkup>();
           CheckupFileStorage app = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            PatientFileStorage patients = new PatientFileStorage("./../../../../Hospital/files/storagepatient.json");

            if (lekar.SelectedItem != null && date.SelectedDate != null)
            {
                foreach (Patient patient in patients.GetAll())
                {
                    foreach (Checkup termin in  checkupcontroller.getAll())
                    {
                        if (l.jmbg == termin.Doctor.jmbg)
                        {
                            if (termin.Date.Date.Equals(date.SelectedDate))
                            {
                                termini.Add(termin);
                            }
                        }

                        if (patient.Id == termin.Patient.Id)
                        {
                            if (termin.Date.Date.Equals(date.SelectedDate))
                            {
                                termini.Add(termin);
                            }
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
                    dostupnoVrijeme.Add(tm.ToString("HH:mm"));

                if (date.SelectedDate == danas)
                {
                    if (tm < DateTime.Now.AddMinutes(30))
                    {
                        dostupnoVrijeme.Remove(tm.ToString("HH:mm"));
                    }
                }

            }
            time.ItemsSource = dostupnoVrijeme;
        }

        //  CheckupFileStorage storage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
        //   Checkup newapp = new Checkup(id,doktor.Id,patient.Id,dt,1,0);

        private void EnabledDugme()
        {
            if (lekar.SelectedItem != null && date.SelectedDate != null && time.SelectedItem != null)
            {
                potvrdi.IsEnabled = true;
            }
            else
            {
                potvrdi.IsEnabled = false;
            }
        } 
       
        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateComponents();
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateComponents();
        }

        private void izaberi_prioritet(object sender, RoutedEventArgs e)
        {

            Prioritet prioritet = new Prioritet(appointmentList, idPatient);
            prioritet.Show();


        }
    }
}


