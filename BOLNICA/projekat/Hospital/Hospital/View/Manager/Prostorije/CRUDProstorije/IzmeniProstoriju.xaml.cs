using Hospital.Controller;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    public partial class IzmeniProstoriju : UserControl
    {
        private ObservableCollection<RoomDTO> rooms;
        private int index;
        private Frame frame;
        private RoomsController controller;
        private RoomDTO room;
        public RoomDTO Room
        {
            get { return room; }
            set { room = value; }
        }
        public IzmeniProstoriju(ObservableCollection<RoomDTO> rooms, RoomDTO selectedItem, int index, Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.rooms = rooms;
            this.index = index;
            this.frame = frame;
            this.room = selectedItem;
            this.controller = new RoomsController();
            addPurpose();
        }

        private void addPurpose()
        {
            namenaTxt.ItemsSource = Enum.GetValues((typeof(Purpose)));
        }
        private void izmenaProstorije(object sender, RoutedEventArgs e)
        {
            controller.update(room);
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
            rooms[index] = room;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }
    }
}
