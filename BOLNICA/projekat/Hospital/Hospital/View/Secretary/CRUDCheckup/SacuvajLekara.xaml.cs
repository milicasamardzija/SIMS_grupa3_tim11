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
using System.Windows.Shapes;

namespace Hospital.Sekretar
{
  
    public partial class SacuvajLekara : Window
    {
        public PatientDTO selectedPatient; 
        public DoctorDTO doctor; 
        public int idD; 
        public int idP; 
        public int idRoom; 
        public DateTime chosenDate; 
        public String time; 
        public ObservableCollection<PatientDTO> listPatient;
        public ObservableCollection<DoctorDTO> listDoctor;
        public CheckupController controller;
      //  public List<Checkup> terms;
        
       
        public SacuvajLekara(ObservableCollection<DoctorDTO> list, DoctorDTO selectedDoctor, PatientDTO patient)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new CheckupController();
            selectedPatient = patient; 
            idP = patient.Id;  
              
            doctor = selectedDoctor;
            idD = selectedDoctor.Id;
            doctorTerms.ItemsSource = loadCheckups(idD);
            //terms = loadCheckups(idD);
          
            
        }

       public List<CheckupDTO> loadCheckups(int id)
        {
            List<CheckupDTO> show = new List<CheckupDTO>(controller.getCheckupDoctors(idD));
            
            return show;
        }
        public void SaveCheckup(object sender, RoutedEventArgs e)
        {
           
            DateTime oldDate = (DateTime)date.SelectedDate;
            getDate(oldDate);
           // getRoom();
            controller.createCheckup(new CheckupDTO(0, idD, idP, chosenDate, 1, 0));
            this.Close();

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
           /* List<Room> availableRooms = controller.availableRooms(chosenDate);

            foreach (Room r in availableRooms)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = r.Id + " " + r.Purpose;
                item.Tag = r.Id;
                listRooms.Items.Add(item);
            }*/
        }
       
        public void Btn(object sender, RoutedEventArgs e)
        {
             getAvailableRoomsbox();
        }

      
    }
}
