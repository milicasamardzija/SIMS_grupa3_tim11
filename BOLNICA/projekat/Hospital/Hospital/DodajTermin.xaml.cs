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
        public DodajTermin(ObservableCollection<Appointment> lista)
        {
            InitializeComponent();
            appointmentList = lista;

        }
        public Patient getPatientFromFile()
        {
            Patient ret = new Patient();

            PatientFileStorage storage = new PatientFileStorage(); //cita pacijente iz fajla
            ret = storage.FindById(54); //uzima onog ciji je zdrastveni karton 54

            return ret;
        }

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

            //sa doktorom
            Appointment newapp = new Appointment(Convert.ToInt32(idText.Text), Convert.ToDateTime(dateText.Text), Convert.ToDateTime(timeText.Text), Convert.ToDouble(durationText.Text), doctor, patient);

            storage.Save(newapp);
            appointmentList.Add(newapp);

            this.Close();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
