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
        public Patient selectedPatient; 
        public Doctor doctor; 
        public int idD; 
        public int idP; 
        public int idRoom; 
        public DateTime chosenDate; 
        public String time; 
        public ObservableCollection<Patient> listPatient;
        public ObservableCollection<Doctor> listDoctor;
        public CheckupController controller;

       
        public SacuvajLekara(ObservableCollection<Doctor> list, Doctor selectedDoctor, Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new CheckupController();
            selectedPatient = patient; 
            idP = patient.Id;  
              
            doctor = selectedDoctor;
            idD = selectedDoctor.Id;
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
            getDate(oldDate);
            getRoom();
            controller.createCheckup(new Checkup(0, idD, idP, chosenDate, idRoom, 0));

        }

        private void getRoom()
        {
            ComboBoxItem item = (ComboBoxItem)listRooms.SelectedItem;
            idRoom = Convert.ToInt32(item.Tag);
        }

        private void getDate(DateTime oldDate)
        {
            String sati = selectedTime.Text.Split(':')[0];
            String minuti = selectedTime.Text.Split(':')[1];
            chosenDate = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, Int32.Parse(sati), Int32.Parse(minuti), 0);
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
                item.Content = r.Id + " " + r.Purpose;
                item.Tag = r.Id;
                listRooms.Items.Add(item);
            }
        }
       
        public void Btn(object sender, RoutedEventArgs e)
        {
             getAvailableRoomsbox();
        }
    }
}
