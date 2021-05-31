using Hospital.Controller;
using Hospital.DTO;
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
    public partial class DodajProstoriju : UserControl
    {
        private ObservableCollection<RoomDTO> rooms;
        private Frame frame;
        private RoomsController controller;
        private RoomDTO room = new RoomDTO();
        private DataGrid roomsView;
        public RoomDTO Room
        {
            get { return room; }
            set { room = value; }
        }
        public DodajProstoriju(DataGrid listaProstorija, ObservableCollection<RoomDTO> rooms, Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.rooms = rooms;
            this.frame = frame;
            this.roomsView = listaProstorija;
            controller = new RoomsController();
            addPurpose();
        }

        private void addPurpose()
        {
            NamenaText.ItemsSource = Enum.GetValues((typeof(Purpose)));
        }

        private void dodavanjeProstorije(object sender, RoutedEventArgs e)
        {
            controller.save(Room);
            roomsView.ItemsSource = controller.getAll();
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

    }
}
