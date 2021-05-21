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
    /// <summary>
    /// Interaction logic for IzmeniPregled.xaml
    /// </summary>
    public partial class IzmeniPregled : Window
    {
        public CheckupController controller;
        public DateTime chosenDate;
        public int idRoom;
        public String time;
        public Checkup oldDatas;
        public int index;
        public ObservableCollection<Checkup> listCheckup;


        public IzmeniPregled(ObservableCollection<Checkup> list, Checkup selected, int sel)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new CheckupController();
            oldDatas = selected;
            index = sel;
            listCheckup = list;
           

        }

        private void Find(object sender, RoutedEventArgs e)
        {  
            DateTime d = (DateTime)datum.SelectedDate;
            SlobodniLekari lekari = new SlobodniLekari(getDate(d), idRoom, oldDatas);
            

            lekari.Show();
        }
        private void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Nadji(object sender, RoutedEventArgs e)
        {
            getAvailableRoomsbox();
        }
        private DateTime getDate(DateTime oldDate)
        {
            String sati = selectedTime.Text.Split(':')[0];
            String minuti = selectedTime.Text.Split(':')[1];
           return chosenDate = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, Int32.Parse(sati), Int32.Parse(minuti), 0);
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
    }
}
