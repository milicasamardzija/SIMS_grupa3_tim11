using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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


        PatientController patientcontroller;
        CheckupController checkupcontroller;
        FunctionalityController funkcionalitycontroller;
        public ObservableCollection<CheckupDTO> appointmentList;
        private List<CheckupDTO> termini;
        public ObservableCollection<PatientDTO> pacijenti;
        public CheckupDTO termin;
        public int index;
        public int idPatient;
        private List<string> lista;
        private List<global::Doctor> lekari;
        private List<string> availableTimes;
        

        public IzmeniTermin(ObservableCollection<CheckupDTO> list, CheckupDTO selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();

            appointmentList = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;
          
            patientcontroller = new PatientController();
            funkcionalitycontroller = new FunctionalityController();
            checkupcontroller = new CheckupController();

           

            lista = new List<string>();
            termini = checkupcontroller.getAll();


          
            foreach (PatientDTO patient in patientcontroller.getAll())
            {
                if (patient.Id == idP)
                {
                    imePacijenta.Text = patient.Name + " " + patient.Surname;
                }
            }

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
            time.ItemsSource = lista;

            CheckAvailableTimes();
            date.SelectedDate = selectedApp.Date;
            time.SelectedValue = selectedApp.Date.ToString("HH:mm");
            time.SelectedItem = time.SelectedValue;

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, termin.Date.AddDays(-3));
            CalendarDateRange kalendar1 = new CalendarDateRange(termin.Date.AddDays(3), DateTime.MaxValue);

            date.BlackoutDates.Add(kalendar);
            date.BlackoutDates.Add(kalendar1);




            DoctorFileStorage df = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
            lekari = df.GetAll();
            lekar.ItemsSource = lekari;
  
           

            foreach (global::Doctor l in lekari)
            {
                if (l.Id == termin.IdDoctor)
                {
                  
                      lekar.SelectedItem = l;
                }
            }
        
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

        
            availableTimes = new List<string>();
            List<Checkup> termini = new List<Checkup>();
            if (lekar.SelectedItem != null && date.SelectedDate != null)

            {

                var item = time.SelectedItem;
                String t = item.ToString();
                String d = date.Text;
                DateTime dt = DateTime.Parse(d + " " + t);
                checkupcontroller.getAvailableTimes(dt, l);



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


            global::Doctor doktor1 = (global::Doctor)lekar.SelectedItem;

            if (time.SelectedIndex != -1)
            {
                var item = time.SelectedItem;
                String t = item.ToString();
                String d = date.Text;
               termin.Date= DateTime.Parse(d + " " + t);

                termin.Room = null;
                termin.IdDoctor = doktor1.Id;
                termin.IdPatient = idPatient;
               
                checkupcontroller.changeCheckup(new CheckupDTO(termin.IdCh, termin.IdDoctor, termin.IdPatient, termin.Date, termin.IdRoom, 0));

                Functionality funkcionalnost = new Functionality(DateTime.Now, idPatient, "izmena");
                funkcionalitycontroller.save(funkcionalnost);


                this.Close();
            }
        }

     

       
     

      

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}