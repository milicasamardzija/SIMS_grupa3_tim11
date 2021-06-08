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
    /// Interaction logic for DodajPage.xaml
    /// </summary>
    
    public partial class DodajPage : Page
    {
        private PocetnaPacijent parent;
        private CheckupController checkupcontroller;
        private FunctionalityController funkcionalitycontroller;
        private PatientController patientcontroller;

        public ObservableCollection<Checkup> appointmentList;
        public int idPatient; //id pacijenta koji je ulogovan
        private List<string> lista;
        private List<global::Doctor> lekari;
        public int count1;
        private const int trajanje = 30;
        private List<string> dostupnoVrijeme;


        public DodajPage(PocetnaPacijent p, ObservableCollection<Checkup> applist)
        {
            InitializeComponent();
            parent = p;
            appointmentList = applist;
            idPatient = p.id;
            potvrdi.IsEnabled = false;
            patientcontroller = new PatientController();
            funkcionalitycontroller = new FunctionalityController();
            checkupcontroller = new CheckupController();
          
         

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

                parent.startWindow.Content = new PreglediP(parent);

            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new PreglediP(parent);
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
            EnabledDugme();
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateComponents();
            EnabledDugme();
        }

        private void lekar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnabledDugme();
        }
        private void izaberi_prioritet(object sender, RoutedEventArgs e)
        {

            parent.startWindow.Content = new PrioritetPage(parent,appointmentList);



        }
    }
}
