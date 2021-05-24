using Hospital.Controller;
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
   
    public partial class PrioritetDatum : Window
    {
        public ObservableCollection<Patient> listPatients;
        public int idP;
        public int idRoom;
        public DateTime chosenDate;
        public CheckupController controller = new CheckupController();
        Patient patient;
        
        public PrioritetDatum(ObservableCollection<Patient> list, Patient selectedPatient)
        {
            InitializeComponent();
            this.DataContext = this;
            listPatients = list;
            patient = selectedPatient;
            idP = patient.Id;

        }
        public DateTime createDate(DateTime date, String time)
        {
           String sati = selectedTime.Text.Split(':')[0];
            String minuti = selectedTime.Text.Split(':')[1];
            DateTime newDate= new DateTime(date.Year, date.Month, date.Day, Int32.Parse(sati), Int32.Parse(minuti), 0);
            return newDate;
        }

        private void FindBtn(object sender, RoutedEventArgs e)
        {
            DateTime oldDate = (DateTime)date.SelectedDate;
            chosenDate = createDate(oldDate, selectedTime.Text);
            ComboBoxItem item = (ComboBoxItem)listRooms.SelectedItem;
            idRoom = Convert.ToInt32(item.Tag);
            SacuvajDatum findByDate = new SacuvajDatum(chosenDate, idRoom, patient);
            findByDate.Show();
        }
        private void getAvailableRoomsbox()
        {
            List<Room> availableRooms = controller.availableRooms(chosenDate);

            foreach (Room r in availableRooms)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = r.Id + " " + r.Purpose;
                item.Tag = r.Id;
                listRooms.Items.Add(item);
            }
        }
        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void findAvailableRoom(object sender, RoutedEventArgs e)
        {
            getAvailableRoomsbox();
        }
    }
}
