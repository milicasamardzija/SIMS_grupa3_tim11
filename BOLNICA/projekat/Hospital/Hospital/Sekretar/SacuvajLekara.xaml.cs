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

       
        public SacuvajLekara(ObservableCollection<Doctor> list, Doctor selectedDoctor, Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            selectedPatient = patient; //je l mi treba foreach bas da ga nadjem ili mogu ovako?
            idP = patient.PatientId; //pokupio je pacijenta 
              
            doctor = selectedDoctor;
            idD = selectedDoctor.DoctorId;
            doctorTerms.ItemsSource = loadCheckups(idD);
          
            
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
           

            /* VOLELA BIH DA ZNAM ZASTO NE RADI...
             * String d = selectedTime.SelectedItem.ToString();
             DateTime newDate = Convert.ToDateTime(d);
             MessageBox.Show(newDate.ToString());
             DateTime time = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, newDate.Hour, newDate.Minute, newDate.Second);
        */
           
             String sati = selectedTime.Text.Split(':')[0];
             MessageBox.Show(sati.ToString());
             String minuti = selectedTime.Text.Split(':')[1];
             MessageBox.Show(minuti.ToString());
             chosenDate = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, Int32.Parse(sati), Int32.Parse(minuti), 0);

            
            
            Checkup newCheckup = new Checkup(0, idD, idP, chosenDate, 0, 0);
            controller.createCheckup(newCheckup);

        }

       public void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void getAvailableRoomsbox() {
            List<Room> availableRooms = controller.availableRooms(chosenDate);

            foreach (Room r in availableRooms)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = r.RoomId + " " + r.Purpose;
                item.Tag = r.RoomId;
                listRooms.Items.Add(item);
            }
        }
       
        public void btn(object sender, RoutedEventArgs e)
        {
             getAvailableRoomsbox();
        }
    }
}
