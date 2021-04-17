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
    /// Interaction logic for DodajTermin.xaml
    /// </summary>
    public partial class DodajTermin : Window
    {

        public ObservableCollection<Appointment> appointmentList;
        public int idPatient; //id pacijenta koji je ulogovan
        public DodajTermin(ObservableCollection<Appointment> lista, int idP)
        {
            InitializeComponent();
            appointmentList = lista;
            idPatient = idP;
        }
        public Patient getPatientFromFile()
        {
            Patient ret = new Patient();
            PatientFileStorage storage = new PatientFileStorage(); 
            List<Patient> patients = storage.GetAll();

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

            //tvooj
            // Appointment newapp = new Appointment(Convert.ToInt32(idText.Text),Convert.ToString(dateText.Text), Convert.ToString(timeText.Text),Convert.ToDouble(durationText.Text),Convert.ToString(doctorText.Text));

            //sa pacijentom
            // Appointment newapp = new Appointment(Convert.ToInt32(idText.Text), Convert.ToString(dateText.Text), Convert.ToString(timeText.Text), Convert.ToDouble(durationText.Text), Convert.ToString(doctorText.Text),patient);

            //mislim da treba da se napravi neka fija koja vraca idAppointmenta koji ne postoji u fajlu i da se automatski taj id ubacuje u novi Appointment
            // Appointment newapp = new Appointment(Convert.ToInt32(idText.Text), Convert.ToDateTime(dateText.Text), Convert.ToDateTime(timeText.Text), Convert.ToDouble(durationText.Text), doctor, patient);
            // Appointment newapp = new Appointment(Convert.ToInt32(idText.Text), Convert.ToDateTime(timeText.Text), Convert.ToDouble(durationText.Text), doctor, patient);
         
            //storage.Save(newapp);
            //appointmentList.Add(newapp);

            this.Close();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
