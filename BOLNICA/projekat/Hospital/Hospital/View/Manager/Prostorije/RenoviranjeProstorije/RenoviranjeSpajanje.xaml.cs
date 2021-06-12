using Hospital.DTO;
using System;
using System.Collections.Generic;
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
using Hospital.Controller;

namespace Hospital.View.Manager.Prostorije.RenoviranjeProstorije
{
    public partial class RenoviranjeSpajanje : UserControl
    {
        private Frame frame;
        private RoomDTO room;
        private RoomsController roomController = new RoomsController();
        private MergeRoomController renovationController = new MergeRoomController();
        private RoomMergeDTO renovation = new RoomMergeDTO();
        public RoomMergeDTO Renovation
        {
            get
            {
                return renovation;
            }
            set
            {
                value = renovation;
            }
        }

        public RenoviranjeSpajanje(Frame frame, DTO.RoomDTO room)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.room = room;
            renovation.IdRoom = room.Id;
            addRooms();
            addPurpose();
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            BeginDate.BlackoutDates.Add(kalendar);
            EndDate.BlackoutDates.Add(kalendar);
            potvrdiBtn.IsEnabled = false;
        }
        private void addRooms()
        {
            brojProstorijeTxt.SelectedText = Convert.ToString(room.Id);
            SobeComboBox.Items.Clear();
            foreach (RoomDTO room in roomController.getAll())
            {
                if (room.Id != renovation.IdRoom)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = Convert.ToString(room.Purpose) + " broj " + Convert.ToString(room.Id);
                    item.Tag = room.Id;
                    SobeComboBox.Items.Add(item);
                }
            }
        }

        private void addPurpose()
        {
            NamenaComboBox.ItemsSource = Enum.GetValues((typeof(Purpose)));
        }
        private void renoviraj(object sender, RoutedEventArgs e)
        {
            renovation.IdRoomSecond = Convert.ToInt32(((ComboBoxItem)SobeComboBox.SelectedItem).Tag);
            renovation.DateBegin = (DateTime)BeginDate.SelectedDate;
            renovation.DateEnd = (DateTime)EndDate.SelectedDate;
            renovation.Purpose = (Purpose)NamenaComboBox.SelectedIndex;
            renovationController.mergeRoomsSchedule(renovation);
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }

        private void SobeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!BeginDate.Text.Equals("") && !EndDate.Text.Equals("") && SobeComboBox.SelectedIndex != -1)
            {
                potvrdiBtn.IsEnabled = true;
            }
        }
    }
}
