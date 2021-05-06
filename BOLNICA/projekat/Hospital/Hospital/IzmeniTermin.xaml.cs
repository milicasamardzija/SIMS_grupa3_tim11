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



        public IzmeniTermin(ObservableCollection<Appointment> list, Appointment selectedApp, int selectedIndex, int idP)
        {
            InitializeComponent();

            appointmentList = list;
            termin = selectedApp;
            index = selectedIndex;
            idPatient = idP;

            idText.SelectedText = Convert.ToString(selectedApp.IdA);

            // time.SelectedText = Convert.ToString(selectedApp.time);

           // lekar.SelectedText = Convert.ToString(selectedApp.doctor);

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
            Doctor doctor = getDoctorFromFile();

            ComboBoxItem item = timeText.SelectedItem as ComboBoxItem;
            String t = item.Content.ToString();
            String d = dateText.Text;
            DateTime dt = DateTime.Parse(d + " " + t);





            termin.DateTime = dt;
            termin.Doctor = doctor;
            termin.Patient = patient;
            termin.IdA = Convert.ToInt32(idText.Text);


            //    termin.doctor = Convert.ToString(doctorText.Text);


            storage.DeleteById(Convert.ToInt16(idText.Text));
            storage.Save(termin);

            this.Close();
        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}