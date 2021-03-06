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
using Hospital.View.Manager.Prostorije.CRUDProstorije;

namespace Hospital
{
    public partial class IzbrisiProstoriju : UserControl
    {
        private ObservableCollection<RoomDTO> rooms = new ObservableCollection<RoomDTO>();
        private int index;
        private Frame frame = new Frame();
        private RoomDTO room = new RoomDTO();
        public RoomDTO Room
        {
            get { return room; }
            set { room = value; }
        }
        public IzbrisiProstoriju(ObservableCollection<RoomDTO> rooms, RoomDTO room, int index,Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.rooms = rooms;
            this.room = room;
            this.index = index;
            this.frame = frame;
            addPurpose();
        }

        private void addPurpose()
        {
            namenaTxt.ItemsSource = Enum.GetValues((typeof(Purpose)));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            IzbrisiProstorijuPotvrda brisanje = new IzbrisiProstorijuPotvrda(room.Id,rooms,index);
            brisanje.Show();
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }
    }
}
