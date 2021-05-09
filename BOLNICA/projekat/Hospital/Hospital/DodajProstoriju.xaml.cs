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
        public ObservableCollection<Room> listRoom;
        public Frame frame;
        public DodajProstoriju(ObservableCollection<Room> list, Frame sobeFrame)
        {
            InitializeComponent();
            listRoom = list;
            frame = sobeFrame;
        }
        public int generisiId()
        {
            int ret = 0;

            RoomFileStorage storage = new RoomFileStorage();
            List<Room> allRooms = storage.GetAll();

            foreach (Room roomBig in allRooms)
            {
                foreach (Room room in allRooms)
                {
                    if (ret == room.RoomId)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void dodavanjeProstorije(object sender, RoutedEventArgs e)
        {
            RoomFileStorage storage = new RoomFileStorage();

            Room newRoom = new Room(generisiId(), Convert.ToInt16(SpratText.Text), false, (Purpose)NamenaText.SelectedIndex, Convert.ToInt16(KapacitetText.Text));

            storage.Save(newRoom);
            listRoom.Add(newRoom);
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

    }
}
