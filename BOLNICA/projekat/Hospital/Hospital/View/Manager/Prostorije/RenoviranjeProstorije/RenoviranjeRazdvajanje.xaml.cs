using Hospital.Controller;
using Hospital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Hospital.View.Manager.Prostorije.RenoviranjeProstorije
{
    public partial class RenoviranjeRazdvajanje : UserControl
    {
        private Frame frame;
        private RoomDTO room;
        private RoomSeparateController renovationController = new RoomSeparateController();
        private RoomRenovationDTO renovation = new RoomRenovationDTO();
        public RoomRenovationDTO Renovation
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
        public RenoviranjeRazdvajanje(Frame frame, DTO.RoomDTO room)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.room = room;
            addPurpose();
            renovation.IdRoom = room.Id;
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            BeginDate.BlackoutDates.Add(kalendar);
            EndDate.BlackoutDates.Add(kalendar);
            potvrdiBtn.IsEnabled = false;
        }

        private void addPurpose()
        {
            TipSobeComboBox.ItemsSource = Enum.GetValues((typeof(Purpose)));
        }

        private void renoviraj(object sender, RoutedEventArgs e)
        {
            renovation.DateBegin = (DateTime)BeginDate.SelectedDate;
            renovation.DateEnd = (DateTime)EndDate.SelectedDate;
            renovationController.separateRoomsSchedule(renovation);
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }

        private void TipSobeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!BeginDate.Text.Equals("") && !EndDate.Text.Equals("") && TipSobeComboBox.SelectedIndex != -1)
            {
                potvrdiBtn.IsEnabled = true;
            }
        }
    }
}
