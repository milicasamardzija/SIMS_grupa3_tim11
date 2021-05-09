using Hospital.Controller;
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

namespace Hospital.Sekretar
{
  
    public partial class SacuvajLekara : Window
    {
        Patient selectedPatient; //pacijentu kome zakazujemo termin 
        Doctor doctor; //doktor koji je izabran
        public int idD; //id tog lekara za checkup
        public int idP; //id tog pacijenta za checkup
        public int idRoom; //id sobe u koju cu da zakazem 
        public DateTime chosenDate; //dan koji ce da izabere 
        public String time; //vreme koje ce da podesi
        public ObservableCollection<Patient> listPatient;
        public ObservableCollection<Doctor> listDoctor;
        public CheckupController controller = new CheckupController();

        public List<Checkup> unavailableTerms { get; set; }
        public SacuvajLekara(ObservableCollection<Doctor> list, Doctor selectedDoctor, Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            selectedPatient = patient; //je l mi treba foreach bas da ga nadjem ili mogu ovako?
            idP = patient.PatientId; //pokupio je pacijenta
          //  MessageBox.Show(idP.ToString());
            doctor = selectedDoctor;
            idD = selectedDoctor.DoctorId;
         //   MessageBox.Show(idD.ToString());

          //  listDoctor = list;
          
            doctorTerms.ItemsSource = loadCheckups(idD);
            //MessageBox.Show(unavailableTerms[0].IdRoom.ToString());
            
        }

       public List<Checkup> loadCheckups(int id)
        {
            List<Checkup> show = new List<Checkup>();
            show = controller.getCheckupDoctors(idD);
            return show;
        }
        public void SaveCheckup(object sender, RoutedEventArgs e)
        {
            DateTime oldDate = (DateTime)date.SelectedDate;
            MessageBox.Show(oldDate.ToString());
            String value =selectedTime.SelectedItem.ToString();

            DateTime d = Convert.ToDateTime(value);
           // TimeSpan t = TimeSpan.ParseExact(value,"HH:mm:ss", null);


            // DateTime time = Convert.ToDateTime(value);  DateTime newDateTime = oldDateTime.Add(TimeSpan.Parse(timeString));
            DateTime time = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, d.Hour, d.Minute, d.Second);
            // chosenDate = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, time.Hour, time.Minute, time.Second);

            Checkup newCheckup = new Checkup(0, idD, idP, time, 0, 0);
            controller.createCheckup(newCheckup);

        }
       public void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
